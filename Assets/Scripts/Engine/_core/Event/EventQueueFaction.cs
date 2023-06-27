using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueFaction
{
    //list of events
    public List<EventModel> Events { get; }

    //constructor
    public EventQueueFaction()
    {
        //create list of events
        Events = new List<EventModel>();
    }

    //add event to list
    public void AddEvent(EventModel eventModel)
    {
        Events.Add(eventModel);
    }

    //send events to global queue
    public void SendEventsToGlobalQueue()
    {
        EventQueueGlobal.Instance.AddEvents(Events);
    }
    
    
}
