using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "Perks/PerkChain")]
public class PerkChainScriptable : SerializedScriptableObject
{
    // List of continuations in the perk chain. 
    [OdinSerialize, ShowInInspector]
    [InlineEditor]
    public List<PerkScriptable> PerkChain { get; set; } = new List<PerkScriptable>();

    private void OnValidate()
    {
        for (int i = 0; i < PerkChain.Count; i++)
        {
            PerkScriptable perk = PerkChain[i];

            // Set the level of the perk based on its position in the chain.
            perk.Level = i + 1;

            // If this isn't the first perk in the chain, add a condition that the previous perk is unlocked.
            if (i > 0)
            {
                PerkScriptable previousPerk = PerkChain[i - 1];

                PerkConditionLevel condition = new PerkConditionLevel(previousPerk.PerkType, previousPerk.Level);

                // If the perk doesn't already have condition with similar signature, add it.
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
