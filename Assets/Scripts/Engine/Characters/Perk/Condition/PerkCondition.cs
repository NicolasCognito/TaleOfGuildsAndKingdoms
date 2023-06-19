using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PerkCondition
{
    public bool Inversed;

    public abstract bool CheckCondition(CharacterModel character);

    public bool Check(CharacterModel character)
    {
        //check if the condition is inversed
        if (Inversed)
        {
            //return the opposite of the condition
            return !CheckCondition(character);
        }
        else
        {
            //return the condition
            return CheckCondition(character);
        }
    }
}
