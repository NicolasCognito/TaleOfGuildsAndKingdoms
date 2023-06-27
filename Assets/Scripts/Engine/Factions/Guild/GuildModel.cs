using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildModel : FactionModel, IEntity
{

    //guild has a name
    public string Name { get; }

    //temporary method to test EventQueue

    /*
    //reference to the global inventory available to the guild
    private InventoryModel inventory;

    
    //reference to the local inventories in each province Guild has a presence
    private List<InventoryModel> localInventories;

    //reference to the roster of heroes
    private RosterModel roster;

    //hire
    public void Hire(CharacterModel hero)
    {
        //add hero to roster
        roster.AddHero(hero);
    }*/
}
