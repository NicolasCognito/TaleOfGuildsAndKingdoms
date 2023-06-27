using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactionModel : IEntity
{
    //faction has EventQueue
    public EventQueueFaction EventQueue { get; }

    //constructor
    public FactionModel()
    {
        EventQueue = new EventQueueFaction();
    }
}
