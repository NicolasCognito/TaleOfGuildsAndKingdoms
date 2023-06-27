using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//generic slot class
//T is the object that is stored in the slot (e.g. IEntity, ResourceModel)
//X is the holder of the slot (e.g. RitualModel, DollModel)
public class SlotModel<T, X>
{
    //containment
    public T Containment { get; set; }
    
    //primary condition method (initial verification of the entity without taking into account other slots)
    private ConditionDelegate primaryCondition;
}
