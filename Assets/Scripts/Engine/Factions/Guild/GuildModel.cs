using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildModel : FactionModel
{

    //guild has a name
    public string Name { get; }



    //temporary method to test EventQueue
    public void TestEventQueue()
    {
        ConditionDelegate testCondition = (args) => { return true; };

        
        //set priority to random value between 0 and 100
        int priority = Random.Range(0, 100);

        //as execution show the guild name
        ExecuteDelegate testExecute = (args) => { Debug.Log($"Event executed by {Name} with priority {priority}"); };


        EventModel testEvent = new EventModel(priority, testCondition, testExecute);

        EventQueue.AddEvent(testEvent);

        //print debug message
        Debug.Log("Event added to the queue");
    }

    //reference to the global inventory available to the guild
    private InventoryModel inventory;

    //constructor
    public GuildModel(string name, InventoryModel inventory = null)
    {
        Name = name;
        this.inventory = inventory;

        //get faction controller instance
        FactionsController factionsController = FactionsController.Instance;

        //add guild to the list of factions
        factionsController.AddFaction(this);

        //debug message
        Debug.Log("Guild " + Name + " added to the list of factions");
    }

    
    /*/reference to the local inventories in each province Guild has a presence
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
