using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResourceModel
{
    //Resource type
    public string resourceType;

    //quality of resource
    public string quality;

    //amount of resource
    public int amount;

    //constructor
    public ResourceModel(string resourceType, string quality, int amount)
    {
        this.resourceType = resourceType;
        this.quality = quality;
        this.amount = amount;
    }
}
