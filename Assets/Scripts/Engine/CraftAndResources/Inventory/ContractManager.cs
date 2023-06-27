using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractManager
{
    // List of all contracts
    private List<ContractModel> contracts;

    public ContractManager()
    {
        contracts = new List<ContractModel>();
    }

    // Method to create a contract (with quality)
    public ContractModel CreateContract(InventoryModel requester, InventoryModel provider, string resourceType, string quality, int resourceAmount, int turnsLeft)
    {
        ContractModel contract = new ContractModel(requester, provider, resourceType, quality, resourceAmount, turnsLeft);
        contracts.Add(contract);
        return contract;
    }

    // Method to cancel a contract
    public void CancelContract(ContractModel contract)
    {
        if (contracts.Contains(contract))
        {
            contracts.Remove(contract);
        }
        else
        {
            throw new System.Exception("No such contract found");
        }
    }

    // Method to update a contract
    public void UpdateContract(ContractModel contract, string resourceType, int resourceAmount, int turnsLeft)
    {
        if (contracts.Contains(contract))
        {
            contract.ResourceType = resourceType;
            contract.ResourceAmount = resourceAmount;
            contract.TurnsLeft = turnsLeft;
        }
        else
        {
            throw new System.Exception("No such contract found");
        }
    }

    // Method to get a list of all contracts
    public List<ContractModel> GetAllContracts()
    {
        return new List<ContractModel>(contracts);
    }

    // Method to get a contract based on some condition
    public ContractModel GetContract(System.Predicate<ContractModel> predicate)
    {
        return contracts.Find(predicate);
    }

    // Method to get all contracts related to a specific inventory
    public List<ContractModel> GetContractsByInventory(InventoryModel inventory)
    {
        return contracts.FindAll(c => c.Requester == inventory || c.Provider == inventory);
    }

    public void ValidateAndExecuteContract(ContractModel contract)
    {
        // Check if the provider has enough resources
        if (!contract.Provider.HasEnoughResources(contract.ResourceType, "", contract.ResourceAmount)) // Assuming "" is a placeholder for any quality
        {
            throw new System.Exception($"Provider does not have enough resources of type {contract.ResourceType}. "
                                    + $"Requested amount: {contract.ResourceAmount}, available amount: {contract.Provider.Resources.Find(r => r.resourceType == contract.ResourceType)?.amount ?? 0}");
        }

        // Remove resources from the provider
        contract.Provider.RemoveResource(new ResourceModel(contract.ResourceType, "", contract.ResourceAmount)); // Assuming "" is a placeholder for any quality

        // Add resources to the requester
        contract.Requester.AddResource(new ResourceModel(contract.ResourceType, "", contract.ResourceAmount)); // Assuming "" is a placeholder for any quality

        // Decrease the turns left, if applicable
        if (contract.TurnsLeft > 0)
        {
            contract.TurnsLeft--;
        }

        // If no turns left, contract should be removed
        if (contract.TurnsLeft == 0)
        {
            CancelContract(contract);
        }
    }
}