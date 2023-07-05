using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeExecutionManager
{
    private InventoryModel inventory;
    private LaborPool laborPool;

    public RecipeExecutionManager(InventoryModel inventory, LaborPool laborPool)
    {
        if (inventory == null || laborPool == null)
        {
            throw new ArgumentNullException(inventory == null ? nameof(inventory) : nameof(laborPool));
        }

        this.inventory = inventory;
        this.laborPool = laborPool;
    }

    public (bool canExecute, int feasibleTier) CanExecuteRecipe(RecipeScriptableObject recipe, ref int stacks)
    {
        int tier = stacks / recipe.tierStep;

        //debug desired tier
        Debug.Log($"Desired tier: {tier}");
        
        while (tier >= 0)
        {
            RecipeConvertor recipeConvertor = recipe.GetConvertorForTier(tier);
            LaborCostModel laborCost = recipe.GetLaborCostForTier(tier);

            // Check if all input resources are available in the necessary quantities.
            bool resourcesAvailable = true;
            foreach (var inputResource in recipeConvertor.inputResources)
            {
                var (hasEnough, _) = inventory.HasEnoughResources(inputResource.type, inputResource.quality, inputResource.amount * stacks);
                if (!hasEnough)
                {
                    resourcesAvailable = false;
                    //debug
                    Debug.Log($"Cannot execute recipe: {recipe.name} for {stacks} stacks at tier {tier}");
                    Debug.Log($"Not enough resources: {inputResource.type} {inputResource.quality} {inputResource.amount * stacks}");
                    break;
                }
            }

            // Check if there are enough laborers of the correct type and quality.
            
            if (resourcesAvailable && HasEnoughLabor(laborCost, laborPool))
            {
                // If we have enough resources and laborers, return true and the current tier.
                return (true, tier);
            }
            
            // If we don't have enough resources or laborers for the current tier, decrement the tier and try again.
            tier--;

            //also update the number of stacks to the feasible tier
            stacks = (tier + 1) * recipe.tierStep;
        }
        
        // If we've checked all tiers and none of them are feasible, return false and -1 for the tier.
        return (false, -1);
    }

    public void ExecuteRecipe(RecipeScriptableObject recipe, int stacks)
    {
        //check if we can execute the recipe, and if we can, get the tier
        var (canExecute, feasibleTier) = CanExecuteRecipe(recipe, ref stacks);

        //if we can't execute the recipe, throw an exception
        if (!canExecute)
        {
            //throw new InvalidOperationException($"Cannot execute recipe: {recipe.name} for {stacks} stacks");
            Debug.Log($"Cannot execute recipe: {recipe.name} for {stacks} stacks");
            return;
        }

        Debug.Log($"Executing recipe: {recipe.name} for {stacks} stacks at tier {feasibleTier}");

        //get the convertor for the feasible tier
        RecipeConvertor recipeConvertor = recipe.GetConvertorForTier(feasibleTier);

        //exchange input resources for output resources
        foreach (var inputResource in recipeConvertor.inputResources)
        {
            inventory.RemoveResource(new ResourceModel(inputResource.type, inputResource.quality, inputResource.amount * stacks));
        }

        foreach (var outputResource in recipeConvertor.outputResources)
        {
            inventory.AddResource(new ResourceModel(outputResource.type, outputResource.quality, outputResource.amount * stacks));
        }
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

    
}