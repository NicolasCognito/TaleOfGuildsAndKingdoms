using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkConditionLevel : PerkCondition
{
    //perk type to check
    public string PerkType;

    public int Level;

    public override bool CheckCondition(CharacterModel character)
    {
        // check if the character has the perk
        if (character.PerksTree.HasPerk(PerkType, Level))
        {
            // return true
            return true;
        }

        // return false
        return false;
    }

    //constructor
    public PerkConditionLevel(string perkType, int level, bool inversed = false) : base()
    {
        //set the perk type
        PerkType = perkType;

        //set the level
        Level = level;

        //set the inversed
        Inversed = inversed;
    }
}
