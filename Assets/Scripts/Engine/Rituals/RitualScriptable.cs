using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

//serialize with Odin
[CreateAssetMenu(fileName = "New Basic Ritual", menuName = "Rituals")]
[System.Serializable]
public class RitualScriptable : SerializedScriptableObjectWithID
{
    //definition
    [OdinSerialize]
    public RitualDefinition definition;

    public bool VerifyRitual(params object[] objects)
    {
        return definition.VerifyRitual(objects);
    }
}
