using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkModel
{

    //ID of the perk
    public string PerkType { get; set; }

    //Level of the perk in chain
    //1 by default, make immutable in inspector
    [Sirenix.OdinInspector.ReadOnly]
    public int Level = 1;

    //expirience associated with this chain
    public int Experience { get; private set; }

    public List<PerkCondition> Conditions;

    public List<string> Tags;

    public bool ConditionsMet(CharacterModel character)
    {
        //check if the conditions are met
        foreach (PerkCondition condition in Conditions)
        {
            //check if the condition is met
            if (!condition.CheckCondition(character))
            {
                //return false
                return false;
            }
        }

        //return true
        return true;
    }

    // Method to increment experience after an action
    public void IncrementExperience(int actionComplexity, int experienceGained)
    {
        // Calculate experience based on action complexity
        int expToAdd = actionComplexity * experienceGained;
        
        // Increment experience
        Experience += expToAdd;
    }

    public PerkModel(PerkScriptable perkScriptable)
    {
        //set the ID
        PerkType = perkScriptable.PerkType;
        
        //set the level
        Level = perkScriptable.Level;

        //expirience
        Experience = 0;

        //set the conditions
        Conditions = perkScriptable.Conditions;

        //set the tags
        Tags = perkScriptable.Tags;
    }
}
