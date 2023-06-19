using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    //properties
    //inventory should belong to the faction and be local to the province
    public FactionModel Faction { get; set; }
    public ProvinceModel Province { get; set; }

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

    public void AddResource(ResourceEnum resourceType, ResourceQualityEnum quality, int amount)
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
        //check if the resource of same type and quality is already present
        ResourceModel existingResource = Resources.Find(r => r.resourceType == request.resourceType && r.quality == request.quality);

        //if it is, we should check if the amount is enough
        if (existingResource != null)
        {
            return existingResource.amount >= request.amount;
        }
        //if it is not, we should return false
        else
        {
            return false;
            throw new System.Exception($"Inventory does not have enough resources of type {request.resourceType}. "
                                    +$"Requested amount: {request.amount}, available amount: {existingResource.amount}");
        }
    }

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

    public InventoryModel(FactionModel faction, ProvinceModel province)
    {
        Faction = faction;
        Province = province;
        Resources = new List<ResourceModel>();
    }
}
