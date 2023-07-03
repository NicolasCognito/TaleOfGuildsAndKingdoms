using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//contract is a request for relocation of resources from one inventory to another
public class ContractModel
{
    //inventory that requested resources
    private InventoryModel requester;

    //inventory that will provide resources
    private InventoryModel provider;

    //requested resource type
    private string resourceType;

    //requested resource amount
    private int resourceAmount;

    //quality of resource
    private string quality;

    //turns left (if set to -1, contract will be active until it will be canceled)
    private int turnsLeft;

    //properties for each field
    public InventoryModel Requester { get => requester; set => requester = value; }

    public InventoryModel Provider { get => provider; set => provider = value; }

    public string ResourceType { get => resourceType; set => resourceType = value; }

    public int ResourceAmount { get => resourceAmount; set => resourceAmount = value; }

    public string Quality { get => quality; set => quality = value; }

    public int TurnsLeft { get => turnsLeft; set => turnsLeft = value; }

    //constructor
    public ContractModel(InventoryModel requester, InventoryModel provider, string resourceType, string quality, int resourceAmount, int turnsLeft)
    {
        this.requester = requester;
        this.provider = provider;
        this.resourceType = resourceType;
        this.resourceAmount = resourceAmount;
        this.turnsLeft = turnsLeft;
        this.quality = quality;
    }

    //execute contract
    
}
