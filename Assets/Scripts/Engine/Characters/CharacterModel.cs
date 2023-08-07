using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : IEntity
{
    //properties
    FactionModel Faction { get; }

    //perks tree model
    public PerksTreeModel PerksTree { get; set; }


    //attributes
    public CharacterAttributeSetModel AttributesSet { get; private set; }

    //constructor
    public CharacterModel(PerksTreeModel perksTree)
    {
        //create attributes set model (each attribute equal to 8 by now)
        AttributesSet = new CharacterAttributeSetModel(8, 8, 8, 8, 8, 8);
        //the perks tree model
        PerksTree = perksTree;

    }
}
