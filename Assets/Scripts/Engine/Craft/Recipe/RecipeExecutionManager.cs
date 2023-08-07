using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeExecutionManager : IResourceReservation
{
    private readonly RecipeScriptableObject recipe;
    private readonly InventoryModel inventory;
    private readonly LaborPool laborPool;
    private readonly ResourceRequestModel currentRequest;
    private int stacks;

    public RecipeExecutionManager(InventoryModel inventory, LaborPool laborPool, RecipeScriptableObject recipe, int stacks = 1)
    {
        if (inventory == null || laborPool == null)
        {
            throw new ArgumentNullException(inventory == null ? nameof(inventory) : nameof(laborPool));
        }

        this.inventory = inventory;
        this.laborPool = laborPool;

        //set initial stacks
        this.stacks = stacks;

        //set recipe
        this.recipe = recipe;

        int tier = GetTierFromStacks(recipe, stacks);

        //initialize current request
        currentRequest = new ResourceRequestModel(recipe, stacks, tier);
    }

    public bool CanExecuteRecipe()
    {
        int tier = GetTierFromStacks(recipe, stacks);

        // Update the current request with the input resources for the specified tier
        currentRequest.UpdateRequests(recipe, stacks, tier);

        var (conflicts, hasEnoughResources) = inventory.ValidateResourceRequests();

        // Check if there are enough laborers of the correct type and quality for the specified tier
        LaborCostModel laborCost = recipe.GetLaborCostForTier(tier);
        bool hasEnoughLabor = HasEnoughLabor(laborCost, laborPool);

        // If we have enough resources and laborers, return true
        if (hasEnoughResources && hasEnoughLabor)
        {
            return true;
        }

        // If we don't have enough resources or laborers, investigate the reasons
        if (!hasEnoughResources)
        {
            Debug.Log("Cannot execute recipe due to insufficient resources. Conflicts:");
            foreach (var conflict in conflicts)
            {
                Debug.Log(conflict);
            }
        }

        if (!hasEnoughLabor)
        {
            Debug.Log("Cannot execute recipe due to insufficient labor.");
        }
        return false;
    }

    public void ExecuteRecipe()
    {
        // First, check if we can execute the recipe
        if (!CanExecuteRecipe())
        {
            throw new InvalidOperationException($"Cannot execute recipe: {recipe.recipeName} for {stacks} stacks.");
        }

        int tier = GetTierFromStacks(recipe, stacks);

        // Get the convertor for the feasible tier
        RecipeConvertor recipeConvertor = recipe.GetConvertorForTier(tier);

        // Remove input resources from the inventory
        foreach (var inputResource in recipeConvertor.inputResources)
        {
            inventory.RemoveResource(new ResourceModel(inputResource.type, inputResource.quality, inputResource.amount * stacks));
        }

        // Add output resources to the inventory
        foreach (var outputResource in recipeConvertor.outputResources)
        {
            inventory.AddResource(new ResourceModel(outputResource.type, outputResource.quality, outputResource.amount * stacks));
        }

        // Remove the resource request from the inventory's list of requested resources
        inventory.RemoveResourceRequest(currentRequest);
    }

    public void IncrementStacks(int incrementBy = 1)
    {
        // Increase the number of stacks by the specified amount
        stacks += incrementBy;

        // Update the current request with the new number of stacks
        currentRequest.UpdateRequests(recipe, stacks, GetTierFromStacks(recipe, stacks));
    }

    public void DecrementStacks(int decrementBy = 1)
    {
        // Decrease the number of stacks by the specified amount, but don't let it go below 1
        stacks = Math.Max(1, stacks - decrementBy);

        // Update the current request with the new number of stacks
        currentRequest.UpdateRequests(recipe, stacks, GetTierFromStacks(recipe, stacks));
    }
    public bool HasEnoughLabor(LaborCostModel laborCost, LaborPool laborPool)
    {
        // Create a copy of the labor pool
        List<LaborerModel> floatingPool = new List<LaborerModel>(laborPool.Laborers);

        // Loop over each laborer requirement in the labor cost model
        foreach (var laborerSlot in laborCost.laborerSlots)
        {
            // Try to find a laborer in the floating pool with the same qualification
            LaborerModel poolLaborer = floatingPool.Find(l => l.qualification == laborerSlot.qualification);

            // If there isn't a laborer with the same qualification in the pool, or if there isn't enough of them, return false
            if (poolLaborer == null)
            {
                //debug
                Debug.Log($"Not enough laborers: {laborerSlot.qualification}");
                return false;
            }

            //otherwise, remove the laborer from the floating pool
            floatingPool.Remove(poolLaborer);
            
        }

        // If all laborer requirements are met, return true
        return true;
    }

    public int GetTierFromStacks(RecipeScriptableObject recipe, int stacks)
    {
        // Calculate the tier based on the stacks and the recipe's tier step
        int tier = stacks / recipe.tierStep;

        // Ensure the tier is within the valid range
        if (tier < 0)
        {
            tier = 0;
        }
        else if (tier > recipe.maxTier)
        {
            tier = recipe.maxTier;
        }

        return tier;
    }

    public void ReserveResources(params object[] args)
    {
        // Ensure that ResourceRequestModel was passed
        if (args == null || args.Length == 0 || args[0] is not ResourceRequestModel request)
        {
            throw new ArgumentException("The first argument must be a ResourceRequestModel.");
        }

        // Add the resource request to the inventory's list of requested resources
        inventory.AddResourceRequest(request);
    }

    public void FreeReservedResources(params object[] args)
    {
        // Ensure that ResourceRequestModel was passed
        if (args == null || args.Length == 0 || args[0] is not ResourceRequestModel request)
        {
            throw new ArgumentException("The first argument must be a ResourceRequestModel.");
        }

        // Remove the resource request from the inventory's list of requested resources
        inventory.RemoveResourceRequest(request);
    }
}