using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InventoryModel
{
    //properties
    //inventory should belong to the faction (can be local to province or global to faction)
    public FactionModel Faction { get; }

    //inventory should have a list of resources
    private List<ResourceModel> Resources { get; }

    //Requested resources are used to validate if there are enough resources to perform all queued operations
    private List<ResourceRequestModel> RequestedResources {get;}

    //delta resources are the resources that are added to the inventory at the end of the turn
    //we should not add the resources to the inventory until the end of the turn
    private List<ResourceModel> DeltaResources { get; }

    //when adding new resources to the inventory, we should check if the resource of same type and quality is already present
    //if it is, we should add the quantity to the existing resource
    //if it is not, we should add the resource to the list
    public void AddResource(string resourceType, string quality, int amount, bool addToDelta = true)
    {
        AddResource(new ResourceModel(resourceType, quality, amount), addToDelta);
    }

    public void AddResource(ResourceModel resource, bool addToDelta = true)
    {
        List<ResourceModel> targetList = addToDelta ? DeltaResources : Resources;
        ResourceModel existingResource = targetList.Find(r => r.resourceType == resource.resourceType && r.quality == resource.quality);

        if (existingResource != null)
        {
            existingResource.amount += resource.amount;
        }
        else
        {
            targetList.Add(resource);
        }
    }

    // Updated HasEnoughResources method to return a result object instead of throwing an exception
    public (bool hasEnough, string message) HasEnoughResources(string resourceType, string quality, int amount)
    {
        return HasEnoughResources(new ResourceModel(resourceType, quality, amount));
    }

    public (bool hasEnough, string message) HasEnoughResources(ResourceModel request)
    {
        // Find the existing resource in the inventory
        ResourceModel existingResource = Resources.Find(r => r.resourceType == request.resourceType && r.quality == request.quality);

        // Calculate the total amount of this resource that has already been requested
        int totalRequestedAmount = RequestedResources
        .SelectMany(r => r.ResourceRequests)
        .Where(r => r.ResourceType == request.resourceType && r.Quality == request.quality)
        .Sum(r => r.Amount);

        // Check if the existing resource is not null and if the amount left after fulfilling all requests is enough for the new request
        if (existingResource != null && existingResource.amount - totalRequestedAmount >= request.amount)
        {
            return (true, "");
        }
        else
        {
            string message = $"Inventory does not have enough resources of type {request.resourceType}. "
                            + $"Requested amount: {request.amount}, available amount: {existingResource?.amount - totalRequestedAmount ?? 0}";
            return (false, message);
        }
    }

    //get resource amount (by type and quality)
    public int GetResourceAmount(string resourceType, string quality)
    {
        //check if the resource of same type and quality is already present
        ResourceModel existingResource = Resources.Find(r => r.resourceType == resourceType && r.quality == quality);

        //if it is, we should return the amount
        if (existingResource != null)
        {
            return existingResource.amount;
        }
        //if it is not, we should return 0
        else
        {
            return 0;
        }
    }

    public void AddResourceRequest(ResourceRequestModel request)
    {
        // Add the request to the list without checking for availability
        RequestedResources.Add(request);
    }

    public void RemoveResourceRequest(ResourceRequestModel request)
    {
        // Simply remove the request from the list
        RequestedResources.Remove(request);
    }

    public (List<string> conflicts, bool result) ValidateResourceRequests()
    {
        List<string> conflicts = new List<string>();

        // Create a copy of the resources list to simulate resource removals
        List<ResourceModel> simulatedResources = new List<ResourceModel>(Resources);

        // Iterate over each request in the RequestedResources list
        foreach (var request in RequestedResources)
        {
            // Check each individual resource request
            foreach (var individualRequest in request.ResourceRequests)
            {
                // Find the corresponding resource in the simulated resources list
                ResourceModel existingResource = simulatedResources.Find(r => r.resourceType == individualRequest.ResourceType && r.quality == individualRequest.Quality);

                // If the resource exists and there's enough of it, subtract the requested amount
                if (existingResource != null && existingResource.amount >= individualRequest.Amount)
                {
                    existingResource.amount -= individualRequest.Amount;
                }
                else
                {
                    // If the resource doesn't exist or there's not enough of it, add a conflict
                    conflicts.Add($"Not enough resources of type {individualRequest.ResourceType}. Requested amount: {individualRequest.Amount}, available amount: {existingResource?.amount ?? 0}");
                }
            }
        }

        bool result = conflicts.Count == 0;

        // Return the list of conflicts
        return (conflicts, result);
    }

    

    /* don't need this for now, will uncomment if needed
    public bool HasEnoughResources(List<ResourceModel> requestedResources)
    {
        foreach (var request in requestedResources)
        {
            // Check if the resource of same type and quality is already present
            ResourceModel existingResource = Resources.Find(r => r.resourceType == request.resourceType && r.quality == request.quality);

            // If it is not present, or if the amount is not enough, return false
            if (existingResource == null || existingResource.amount < request.amount)
            {
                return false;
            }
        }

        // If we have checked all requested resources and didn't return false, then we have enough of all resources
        return true;
    }
    */


    //Remove resources from the inventory (if reached 0, remove from the list)
    public void RemoveResource(ResourceModel request)
    {
        ResourceModel existingResource = Resources.Find(r => r.resourceType == request.resourceType && r.quality == request.quality);

        if (existingResource != null)
        {
            existingResource.amount -= request.amount;

            if (existingResource.amount <= 0)
            {
                Resources.Remove(existingResource);
            }
        }
        else
        {
            throw new System.Exception($"Cannot remove resources. Inventory does not contain the resource of type {request.resourceType}.");
        }
    }

    //contract creation (province to global inventory, single turn by default)
    public void TransferResourceToGlobalInventory(string resourceType, int resourceAmount, int turns = 1)
    {
        
    }


    //merge inventory
    private void MergeInventory()
    {
        //loop through the resources in the delta
        foreach (var resource in DeltaResources)
        {
            //add the resource to the inventory
            AddResource(resource, false);
        }

        //clear the delta resources
        DeltaResources.Clear();
    }

    public InventoryModel(FactionModel faction)
    {
        Faction = faction;
        Resources = new List<ResourceModel>();
        DeltaResources = new List<ResourceModel>();
        RequestedResources = new List<ResourceRequestModel>();

        //subscribe to the end of turn event
        UnityAction<string> mergeInventoryAction = new UnityAction<string>(phase => {
        if (phase == "Active") 
            {
            MergeInventory();
            }
        });

        GamePhasesManager.onPhaseCompleted.AddListener(mergeInventoryAction);
    }
}
