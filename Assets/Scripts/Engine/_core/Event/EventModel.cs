using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventModel
{
    // priority defines the order in which events are executed
    private int _priority;

    public int Priority
    {
        get => _priority;
        set => _priority = value;
    }

    // instances of delegates
    public ConditionDelegate Condition { get; set; }
    public ExecuteDelegate Execute { get; set; }

    // try to execute the event
    public void CallEvent(params object[] args)
    {
        // if the event is still valid
        if (Condition != null && Condition(args))
        {
            // execute the event
            Execute?.Invoke(args);
        }
        // otherwise
        else
        {
            // throw an exception
            throw new System.Exception("Event is not valid");
        }
    }

    // constructor
    public EventModel(int priority, ConditionDelegate condition, ExecuteDelegate execute)
    {
        // set the priority
        _priority = priority;

        // set the delegates
        Condition = condition;
        Execute = execute;
    }
}
