using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//generic slot class
//T is the object that is stored in the slot (e.g. IEntity, ResourceModel)
//X is the holder of the slot (e.g. RitualModel, DollModel)
public abstract class Slot<T, X>
{
    //delegate for condition
    public delegate bool Condition(T entity, X holder);
}
