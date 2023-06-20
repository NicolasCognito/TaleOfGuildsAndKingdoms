using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkModel
{

    //Level of the perk in chain
    //1 by default, make immutable in inspector
    [Sirenix.OdinInspector.ReadOnly]
    public int Level = 1;

    //cost of the perk in perk points
    public int Cost;

    public List<PerkCondition> Conditions;

    public List<PerkTagsEnum> Tags;

    public PerkModel(PerkScriptable perkScriptable)
    {
        
        //set the level
        Level = perkScriptable.Level;

        //set the cost
        Cost = perkScriptable.Cost;

        //set the conditions
        Conditions = perkScriptable.Conditions;

        //set the tags
        Tags = perkScriptable.Tags;
    }
}
