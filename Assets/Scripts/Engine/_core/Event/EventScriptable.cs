using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScriptable : SerializedScriptableObjectWithID
{
    //definition of the event
    [SerializeField]
    private EventDefinition _definition;

    public EventDefinition Definition
    {
        get => _definition;
    }
    // priority defines the order in which events are executed
    [SerializeField] 
    private int _priority;

    public int Priority
    {
        get => _priority;
        set => _priority = value;
    }

    

}
