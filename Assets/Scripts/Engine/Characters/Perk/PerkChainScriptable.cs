using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "Perks/PerkChain")]
public class PerkChainScriptable : SerializedScriptableObjectWithID
{
    //property PerkType is a wrapper for the ID
    public string ID { get { return uID; } set { uID = value; } }

    // List of continuations in the perk chain. 
    [OdinSerialize, ShowInInspector]
    [InlineEditor]
    public List<PerkScriptable> PerkChain { get; set; } = new List<PerkScriptable>();


    private void OnValidate()
    {
        for (int i = 0; i < PerkChain.Count; i++)
        {
            PerkScriptable perk = PerkChain[i];
            perk.Level = i + 1;
            perk.PerkType = ID;  // Set the ID of the perk

            if (i > 0)
            {
                PerkScriptable previousPerk = PerkChain[i - 1];
                PerkConditionLevel condition = new PerkConditionLevel(previousPerk.PerkType, previousPerk.Level);

                foreach (PerkConditionLevel existingCondition in perk.Conditions)
                {
                    if (existingCondition.PerkType == condition.PerkType && existingCondition.Level == condition.Level)
                    {
                        break;
                    }
                }
            }
        }
    }
}
