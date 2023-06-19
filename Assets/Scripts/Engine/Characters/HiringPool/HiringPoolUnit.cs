using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiringPoolUnit
{
    //hero model
    public CharacterModel Hero { get; set; }

    //Bids on this hero from different factions
    public Dictionary<GuildModel, int> Bids { get; set; }

    //list of factions that could place bids on this hero
    public List<GuildModel> BiddingFactions { get; set; }

    //minimal bid for this hero
    public int MinimalBid { get; set; }

    //turns before decision
    public int TurnsBeforeDecision { get; set; }
}
