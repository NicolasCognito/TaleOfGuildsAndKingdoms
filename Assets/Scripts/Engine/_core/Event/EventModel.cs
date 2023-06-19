using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventModel
{
    //priority defines the order in which events are executed
    private int _priority;

    public int Priority
    {
        get => _priority;
        set => _priority = value;
    }

    /*methods shouldn't take any external args as all necessary should be in the */

    //condition defines whether the event should be executed
    //usecase is to check if the event is still valid
    public abstract bool Condition();

    //execute the event
    public abstract void Execute();

    //try to execute the event
    public void TryExecute()
    {
        //if the event is still valid
        if (Condition())
        {
            //execute the event
            Execute();
        }
        //otherwise
        else
        {
            //throw an exception
            throw new System.Exception("Event is not valid");
        }
    }
}
