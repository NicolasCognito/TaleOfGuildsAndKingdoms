using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : IEntity
{
    //properties
    FactionModel Faction { get; }

    //perks tree model
    public PerksTreeModel PerksTree { get; set; }


    //stats dictionary
    public Dictionary<string, CharacterAttributeModel> Attributes { get; set; }

    //constructor
    public CharacterModel(PerksTreeModel perksTree, List<CharacterAttributeModel> attributes)
    {
        //

        //create the stats dictionary
        Attributes = new Dictionary<string, CharacterAttributeModel>();

        //loop through the stats
        foreach (CharacterAttributeModel attribute in attributes)
        {
            //add the stat to the dictionary
            Attributes.Add(attribute.AttributeType, attribute);
        }

        //create the perks tree model
        PerksTree = perksTree;

    }
}
