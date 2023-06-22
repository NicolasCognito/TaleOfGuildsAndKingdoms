using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

//serialize with Odin
[System.Serializable]
public abstract class RitualScriptable : SerializedScriptableObjectWithID
{

    //instead of list of slots, we will have separate fields for each slot in the inherited classes
    /*
    //list of slots
    [OdinSerialize, ListDrawerSettings(Expanded = true)]
    public List<SlotGenericSerialized<IEntity, RitualModel>> Slots { get; set; }
    */

    public abstract bool VerifyRitual(params object[] objects);

    //constructor
    public RitualScriptable()
    {
        //Slots = new List<SlotGenericSerialized<IEntity, RitualModel>>();
    }
}
