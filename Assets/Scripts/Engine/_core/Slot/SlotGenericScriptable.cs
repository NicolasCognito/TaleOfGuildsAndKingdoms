using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

//refactoring code without this class, so it's deprecated

//T is the object that is stored in the slot (e.g. IEntity, ResourceModel)
//X is the holder of the slot (e.g. RitualModel, DollModel)
[InlineEditor]
public class SlotGenericScriptable<T, X> : SerializedScriptableObjectWithID
{
    //name of slot
    [ShowInInspector]
    public string name;
}
