using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueGlobal
{
    //singleton
    private static EventQueueGlobal _instance;

    public static EventQueueGlobal Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventQueueGlobal();
            }

            return _instance;
        }
    }

    //list of events
    public List<EventModel> events = new List<EventModel>();

    //copy events from faction queue
    public void AddEvents(List<EventModel> events)
    {
        this.events.AddRange(events);
    }


    //add event to the queue
    public void AddEvent(EventModel eventModel)
    {
        events.Add(eventModel);
    }

    //iterate through the queue and execute events
    public void ExecuteEvents()
    {
        //sort the events by priority
        events.Sort((x, y) => x.Priority.CompareTo(y.Priority));

        //iterate through the events
        for (int i = 0; i < events.Count; i++)
        {
            //try to execute the event
            events[i].CallEvent();
        }
    }    
}
