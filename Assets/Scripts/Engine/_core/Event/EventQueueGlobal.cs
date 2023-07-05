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

        // Subscribe to UnityEvent
        eventModel.onEventCompleted.AddListener(onEventCompleted);
    }

    private void onEventCompleted()
    {
        // unsubscribe from the event
        EventModel eventModel = events[0];
        eventModel.onEventCompleted.RemoveListener(onEventCompleted);
        
        // Remove event from the queue
        events.RemoveAt(0);

        //if there are more events, execute next event
        if (events.Count > 0)
        {
            events[0].CallEvent();
        }
    }

    //sort events by priority
    public void SortEvents()
    {
        events.Sort((x, y) => x.Priority.CompareTo(y.Priority));
    }

    //iterate through the queue and execute events
    public void ExecuteEvents()
    {
        //sort events by priority
        SortEvents();

        //call first event
        events[0].CallEvent();
    }

    public void MergeQueues()
    {
        //get faction controller instance
        FactionsController factionsController = FactionsController.Instance;

        //get all factions queues
        List<EventQueueFaction> queues = factionsController.GetAllFactionsQueues();

        //iterate through the queues
        foreach (EventQueueFaction factionQueue in queues)
        {
            //add events to the faction queue
            AddEvents(factionQueue.Events);
        }

        //sort the events by priority
        events.Sort((x, y) => x.Priority.CompareTo(y.Priority));

    }
}
