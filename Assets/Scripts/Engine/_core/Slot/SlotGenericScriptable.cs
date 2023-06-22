using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

//refactoring code without this class, so it's deprecated

//T is the object that is stored in the slot (e.g. IEntity, ResourceModel)
//X is the holder of the slot (e.g. RitualModel, DollModel)
[Serializable]
public abstract class SlotGenericSerialized<T, X>
{
    public string Name { get; set; }

    //primary condition abstract method (initial verification of the entity without taking into account other slots)
    //takes array of objects as parameter, also takes the containment of the slot as the first parameter
    public abstract bool PrimaryCondition(T containment, params object[] objects);
}
