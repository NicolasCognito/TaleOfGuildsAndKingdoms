using System.Collections;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

//serialize with Odin
[CreateAssetMenu(fileName = "New Ritual", menuName = "Rituals/Ritual")]
public class RitualScriptable : SerializedScriptableObjectWithID
{
    //strategy of ritual
    [OdinSerialize]
    public RitualStrategy Strategy { get; set; }

    //list of slots
    [OdinSerialize]
    public List<SlotGenericScriptable<IEntity, RitualModel>> Slots { get; set; }

    //constructor
    public RitualScriptable()
    {
        Slots = new List<SlotGenericScriptable<IEntity, RitualModel>>();
    }
}
