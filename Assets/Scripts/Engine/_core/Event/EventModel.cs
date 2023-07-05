using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventModel
{
    public UnityEvent onEventCompleted;

    // priority defines the order in which events are executed
    private int _priority;

    public int Priority
    {
        get => _priority;
        set => _priority = value;
    }

    // instances of delegates
    protected ConditionDelegate Condition { get; set; }
    protected ExecuteDelegate Execute { get; set; }

    // try to execute the event
    public void CallEvent(params object[] args)
    {
        // if the event is still valid
        if (Condition != null && Condition(args))
        {
            // execute the event
            Execute?.Invoke(args);

            
            onEventCompleted.Invoke();
        }
        // otherwise
        else
        {
            //debug log with information about the event
            Debug.Log("Event " + Execute.Method.Name + " is no longer valid");

            // call the event completed event
            onEventCompleted.Invoke();
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

        //unity event
        onEventCompleted = new UnityEvent();
    }

    //constructor (from scriptable object)
    public EventModel(EventScriptable scriptable)
    {
        // set the priority
        _priority = scriptable.Priority;

        // set the delegates
        Condition = scriptable.Definition.Condition;
        Execute = scriptable.Definition.Execute;

        //unity event
        onEventCompleted = new UnityEvent();
    }
}
