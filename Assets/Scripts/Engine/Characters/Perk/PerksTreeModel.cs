using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//perk tree model contains references to perks and perks chains for a specific character
//also it contains applied modifiers, such as reduced cost or attributes requirements
public class PerksTreeModel
{
    //enum with possible perk states
    private enum PerkStateEnum
    {
        //locked
        Locked,
        //unlocked
        Unlocked,
        //purchased
        Purchased,
        //deactivated
        Deactivated
    }

    //list of all perk chains
    //used when rebuilding the perk tree for some reason
    private List<PerkChainScriptable> perkChains = new List<PerkChainScriptable>();
    
    //private dictionary contains all perks as models in keys and their states as values
    private Dictionary<PerkModel, PerkStateEnum> perks = new Dictionary<PerkModel, PerkStateEnum>();

    

    //constructor takes list of perks and perk chains
    public PerksTreeModel(List<PerkChainScriptable> perkChains)
    {
        //set the perk chains
        this.perkChains = perkChains;

        //loop through the perk chains, convert content to models and add to the dictionary
        foreach (var perkChain in perkChains)
        {
            //loop through the perks
            foreach (var perk in perkChain.PerkChain)
            {
                //create the perk model
                var perkModel = new PerkModel(perk);

                //add the perk to the dictionary
                perks.Add(perkModel, PerkStateEnum.Locked);
            }
        }
    }

    //check for the perk with specific type level
    // check for the perk with specific type level
    public bool HasPerk(string perkID, int level = 1)
    {
        // iterate through all perks
        foreach (var perk in perks)
        {
            // check if the perk has the same type and level
            if (perk.Key.PerkType == perkID && perk.Key.Level == level && perk.Value == PerkStateEnum.Purchased)
            {
                // return true
                return true;
            }
        }
        // return false
        return false;
    }

    //update the perk states
    public void UpdatePerkStates(CharacterModel character)
    {
        //create new dictionary
        var newPerkStates = new Dictionary<PerkModel, PerkStateEnum>();

        //loop through the perks, perform actions based on their states
        //if purchased, add to the new dictionary with the same state
        //if locked or unlocked, check the conditions and add to the new dictionary with the new state
        foreach (var perk in perks)
        {
            //check the state
            switch (perk.Value)
            {
                //if purchased, add to the new dictionary with the same state
                case PerkStateEnum.Purchased:
                    newPerkStates.Add(perk.Key, perk.Value);
                    break;
                //if locked or unlocked, check the conditions and add to the new dictionary with the new state
                case PerkStateEnum.Locked:
                case PerkStateEnum.Unlocked:
                    //check the conditions
                    if (perk.Key.ConditionsMet(character))
                    {
                        //add to the new dictionary with the new state
                        newPerkStates.Add(perk.Key, PerkStateEnum.Unlocked);
                    }
                    else
                    {
                        //add to the new dictionary with the new state
                        newPerkStates.Add(perk.Key, PerkStateEnum.Locked);
                    }
                    break;
                //if deactivated, add to the new dictionary with the same state
                case PerkStateEnum.Deactivated:
                    newPerkStates.Add(perk.Key, perk.Value);
                    break;
                //by default throw an exception
                default:
                    throw new System.Exception("Unknown perk state");
            }
        }

        
    }

    //purchase the perk (for now for free)
    public void PurchasePerk(PerkModel perk, CharacterModel character)
    {
        //check if the perk is unlocked
        if (perks[perk] == PerkStateEnum.Unlocked)
        {
            //set the state to purchased
            perks[perk] = PerkStateEnum.Purchased;

            //update the perk states
            UpdatePerkStates(character);
        }
        else
        {
            //throw an exception
            throw new System.Exception("Perk is not unlocked");
        }
    }
}

