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
    public Dictionary<CharacterStatsEnum, CharacterStatModel> Stats { get; set; }

    /*/get faction based on subclass of character
    private FactionModel GetFactionModel()
    {
        //check if the character is a GuildMember
        if (this is GuildMemberModel)
        {
            //return the guild faction
            return FactionModel.Guild;
        }

        //check if the character is a KingdomMember
        if (this is KingdomMemberModel)
        {
            //return the kingdom faction
            return FactionModel.Kingdom;
        }
    }*/

    //constructor
    public CharacterModel(PerksTreeModel perksTree, List<CharacterStatModel> stats)
    {
        //

        //create the stats dictionary
        Stats = new Dictionary<CharacterStatsEnum, CharacterStatModel>();

        //loop through the stats
        foreach (CharacterStatModel stat in stats)
        {
            //add the stat to the dictionary
            Stats.Add(stat.StatType, stat);
        }

        //create the perks tree model
        PerksTree = perksTree;

    }
}
