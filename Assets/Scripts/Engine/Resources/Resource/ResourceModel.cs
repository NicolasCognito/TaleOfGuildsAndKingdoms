using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceModel
{
    //Resource type
    public ResourceEnum resourceType;

    //quality of resource
    public ResourceQualityEnum quality;

    //amount of resource
    public int amount;

    //constructor
    public ResourceModel(ResourceEnum resourceType, ResourceQualityEnum quality, int amount)
    {
        this.resourceType = resourceType;
        this.quality = quality;
        this.amount = amount;
    }
}
