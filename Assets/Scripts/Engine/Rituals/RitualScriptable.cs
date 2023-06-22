using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

//serialize with Odin
[CreateAssetMenu(fileName = "New Ritual", menuName = "Rituals/Ritual")]
public class RitualScriptable : SerializedScriptableObjectWithID
{
    //strategy of ritual
    [OdinSerialize, InlineEditor]
    public RitualStrategy Strategy { get; set; }

    //list of slots
    [OdinSerialize, ListDrawerSettings(Expanded = true), InlineEditor]
    public List<SlotGenericScriptable<IEntity, RitualModel>> Slots { get; set; }

    //constructor
    public RitualScriptable()
    {
        Slots = new List<SlotGenericScriptable<IEntity, RitualModel>>();
    }
}
