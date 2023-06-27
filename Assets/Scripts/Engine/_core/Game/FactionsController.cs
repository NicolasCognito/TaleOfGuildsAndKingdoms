using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//singleton class to store all factions present in game
//should be removed after refactoring
public class FactionsController
{
    //singleton instance
    private static FactionsController _instance;

    //singleton instance getter
    public static FactionsController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FactionsController();
            }
            return _instance;
        }
    }

    //factions list
    private List<FactionModel> _factions = new List<FactionModel>();

    //add faction to the list
    public void AddFaction(FactionModel faction)
    {
        _factions.Add(faction);

        //instance of global event queue
        EventQueueGlobal eventQueue = EventQueueGlobal.Instance;
    }

    //return queue of events for faction
    public EventQueueFaction GetFactionQueue(FactionModel faction)
    {
        //one liner to get the queue
        return _factions.Find(x => x == faction).EventQueue;
    }

    //return queues for all factions present in game
    public List<EventQueueFaction> GetAllFactionsQueues()
    {
        //list of queues
        List<EventQueueFaction> queues = new List<EventQueueFaction>();

        //iterate through the factions
        foreach (FactionModel faction in _factions)
        {
            //add queue to the list
            queues.Add(faction.EventQueue);
        }

        //return list of queues
        return queues;
    }
}
