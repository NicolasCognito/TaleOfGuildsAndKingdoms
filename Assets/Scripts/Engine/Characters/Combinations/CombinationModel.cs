using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

//combinations is used as the reward when player manages to get certain perks combo
//it usually provides point or two to certain attribute
//should be unlocked manually, after unlocking remove from the list
[CreateAssetMenu(menuName = "Perks/Combination")]
public class CombinationModel : SerializedScriptableObjectWithID
{
    public string Name { get { return uID; } set { uID = value; } }

    // List of perks that must be unlocked to activate this combination
    //serialize with odin inspector
    [System.Serializable]
    public class StringIntTupple
    {
        public string Name;
        public int Value;
    }

    [OdinSerialize, ShowInInspector]
    public List<StringIntTupple> RequiredPerks { get; set; } = new List<StringIntTupple>();

    [OdinSerialize, ShowInInspector]
    public List<StringIntTupple> AttributePointRewards { get; set; } = new List<StringIntTupple>();
}
