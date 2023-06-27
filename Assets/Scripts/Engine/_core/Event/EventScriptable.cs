using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventScriptable : SerializedScriptableObjectWithID
{
    // priority defines the order in which events are executed
    [SerializeField] 
    private int _priority;

    public int Priority
    {
        get => _priority;
        set => _priority = value;
    }

    // abstract methods
    public abstract bool Condition(params object[] args);

    public abstract void Execute(params object[] args);

}
