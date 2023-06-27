using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    //properties
    //inventory should belong to the faction (can be local to province or global to faction)
    public FactionModel Faction { get; }

    //inventory should have a list of resources
    public List<ResourceModel> Resources { get; set; }

    //when adding new resources to the inventory, we should check if the resource of same type and quality is already present
    //if it is, we should add the quantity to the existing resource
    //if it is not, we should add the resource to the list
    public void AddResource(ResourceModel resource)
    {
        //check if the resource of same type and quality is already present
        ResourceModel existingResource = Resources.Find(r => r.resourceType == resource.resourceType && r.quality == resource.quality);

        //if it is, we should add the quantity to the existing resource
        if (existingResource != null)
        {
            existingResource.amount += resource.amount;
        }
        //if it is not, we should add the resource to the list
        else
        {
            Resources.Add(resource);
        }
    }

    public void AddResource(string resourceType, string quality, int amount)
    {
        //check if the resource of same type and quality is already present
        ResourceModel existingResource = Resources.Find(r => r.resourceType == resourceType && r.quality == quality);

        //if it is, we should add the quantity to the existing resource
        if (existingResource != null)
        {
            existingResource.amount += amount;
        }
        //if it is not, we should add the resource to the list
        else
        {
            Resources.Add(new ResourceModel(resourceType, quality, amount));
        }
    }

    //Ensure that the inventory has enough resources to satisfy the request
    public bool HasEnoughResources(ResourceModel request)
    {
        ResourceModel existingResource = Resources.Find(r => r.resourceType == request.resourceType && r.quality == request.quality);

        if (existingResource != null)
        {
            return existingResource.amount >= request.amount;
        }
        else
        {
            throw new System.Exception($"Inventory does not have enough resources of type {request.resourceType}. "
                                        +$"Requested amount: {request.amount}, available amount: {existingResource?.amount ?? 0}");
        }
    }

    public bool HasEnoughResources(string resourceType, string quality, int amount)
    {
        // Check if the resource of same type and quality is already present
        ResourceModel existingResource = Resources.Find(r => r.resourceType == resourceType && r.quality == quality);

        // If it is, we should check if the amount is enough
        if (existingResource != null)
        {
            return existingResource.amount >= amount;
        }
        // If it is not, we should return false
        else
        {
            return false;
        }
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

    //contract (province to global inventory)
    public void SendResourceToGlobalInventory(string resourceType, int resourceAmount, int turns = 1)
    {
        
    }

    public InventoryModel(FactionModel faction)
    {
        Faction = faction;
        Resources = new List<ResourceModel>();
    }
}
