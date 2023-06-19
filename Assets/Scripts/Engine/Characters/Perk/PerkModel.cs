using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkModel
{
    //enum to store the type of perk
    public PerksEnum PerkType;

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
        //set the perk type
        PerkType = perkScriptable.PerkType;

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
