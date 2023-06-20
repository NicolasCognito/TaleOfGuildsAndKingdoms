using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkConditionStat : PerkCondition 
{
    //stat to check
    public string Stat;

    //value to check
    public int Value;

    public override bool CheckCondition(CharacterModel character)
    {
        //check if the character has the stat
        if (character.Attributes.ContainsKey(Stat))
        {
            //check if the stat value is greater than or equal to the value
            if (character.Attributes[Stat].Value >= Value)
            {
                //return true
                return true;
            }
        }

        //return false
        return false;
    }
}
