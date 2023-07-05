using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventDefinition
{
    // abstract methods
    public abstract bool Condition(params object[] args);

    public abstract void Execute(params object[] args);

}
