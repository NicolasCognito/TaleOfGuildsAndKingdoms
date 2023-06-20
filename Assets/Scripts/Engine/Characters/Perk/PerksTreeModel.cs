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

    //dictionary contains all perks and their states
    private Dictionary<PerkScriptable, PerkStateEnum> PerkStates = new Dictionary<PerkScriptable, PerkStateEnum>();

    //list of all perk chains
    private List<PerkChainScriptable> PerkChains = new List<PerkChainScriptable>();
    
    //private dictionary contains all perks as models in keys and their states as values
    private Dictionary<PerkModel, PerkStateEnum> PerkModels = new Dictionary<PerkModel, PerkStateEnum>();

    //convert one dictionary to another
    private void ConvertPerkScriptableToPerkModel()
    {
        //clear the dictionary
        PerkModels.Clear();

        //iterate through all perks
        foreach (var perk in PerkStates)
        {
            //create new perk model
            var perkModel = new PerkModel(perk.Key);

            //add the perk model to the dictionary
            PerkModels.Add(perkModel, perk.Value);
        }
    }

    //constructor takes list of perks and perk chains
    public PerksTreeModel(List<PerkScriptable> perks, List<PerkChainScriptable> perkChains)
    {
        //iterate through all perks
        foreach (var perk in perks)
        {
            //add the perk to the dictionary
            PerkStates.Add(perk, PerkStateEnum.Locked);
        }

        //iterate through all perk chains
        foreach (var perkChain in perkChains)
        {
            //iterate through all perks in the perk chain
            foreach (var perk in perkChain.PerkChain)
            {
                //add the perk to the dictionary
                PerkStates.Add(perk, PerkStateEnum.Locked);
            }

            //add the perk chain to the list
            PerkChains.Add(perkChain);
        }
    }

    //check for the perk with specific type level
    // check for the perk with specific type level
    public bool HasPerk(string perkID, int level = 1)
    {
        // iterate through all perks
        foreach (var perk in PerkStates)
        {
            // check if the perk has the same type and level
            if (perk.Key.uID == perkID && perk.Key.Level == level && perk.Value == PerkStateEnum.Purchased)
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
        var newPerkStates = new Dictionary<PerkScriptable, PerkStateEnum>();

        //iterate through all perks
        foreach (var perk in PerkStates)
        {
            //if not purchased, check condition
            if (perk.Value != PerkStateEnum.Purchased)
            {
                //check if the conditions are met
                if (perk.Key.ConditionsMet(character))
                {
                    //add the perk to the dictionary
                    newPerkStates.Add(perk.Key, PerkStateEnum.Unlocked);
                }
                else
                {
                    //add the perk to the dictionary
                    newPerkStates.Add(perk.Key, PerkStateEnum.Locked);
                }
            }
        }
    }

}

