using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[CreateAssetMenu(menuName = "Perks/Perk")]
public class PerkScriptable : SerializedScriptableObjectWithID
{
    //property PerkType is a wrapper for the ID
    public string PerkType { get { return uID; } set { uID = value; } }

    //Level of the perk in chain
    [Sirenix.OdinInspector.ReadOnly]
    public int Level;

    //cost of the perk in perk points
    public int Cost;

    //TODO: make it private
    [ListDrawerSettings]
    [OdinSerialize, ShowInInspector]
    public List<PerkCondition> Conditions = new List<PerkCondition>();

    public List<PerkTagsEnum> Tags;

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
}
