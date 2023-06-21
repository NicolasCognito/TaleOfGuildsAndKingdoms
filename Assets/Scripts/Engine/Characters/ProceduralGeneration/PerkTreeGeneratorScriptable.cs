using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;


//this perk tree generation model is used to generate a perk tree for a character
//for now, it's quite simple, but it will be expanded upon later
//for each different race, there will be a different perk tree generation model
//for example, dark elves would more often get perk Vile and Assassin class chain, 
//while dwarves would more often get perk Tough and Alchemist class chain

//how it works:
//after character is generated, the perk tree generation model is used to 
//generate a perk tree model with all references to perk scriptables.
//in generated perk tree model, all possible perks and chains are presented
//along with a number from 5 to 100, which represents the chance of getting this perk.
//perks can't duplicate, so if perk is already in the perk tree model, it won't be added again
[CreateAssetMenu(menuName = "Perks/Perk Tree Generation Model")]
public class PerkTreeGeneratorScriptable : SerializedScriptableObject
{
    [System.Serializable]
    private class PerkGenerator
    {
        public PerkScriptable Perk;

        [ShowIf("@!Guaranteed"), DisableIf("Guaranteed")]
        public int Chance;

        public bool Guaranteed = false;
    }

    [System.Serializable]
    private class PerkChainGenerator
    {
        public PerkChainScriptable PerkChain;

        [ShowIf("@!Guaranteed"), DisableIf("Guaranteed")]
        public int Chance;

        public bool Guaranteed = false;
    }

    // Dictionaries for perks and perk chains with their chance to be chosen
    [OdinSerialize] 
    private List<PerkGenerator> PerkChances = new List<PerkGenerator>();

    [OdinSerialize] 
    private List<PerkChainGenerator> PerkChainChances = new List<PerkChainGenerator>();

    // This method generates a PerkTreeModel based on the perk and chain chances
    public PerksTreeModel GeneratePerkTreeModel(CharacterGeneratorScriptable character)
    {
        // List of perk chains to be added to the PerkTreeModel
        List<PerkChainScriptable> perkChains = new List<PerkChainScriptable>();

        //for each perk chain roll a random number and if it's greater than the chance, add it to the list
        foreach (PerkChainGenerator chainGenerator in PerkChainChances)
        {
            if (Random.Range(0, 100) < chainGenerator.Chance)
            {
                perkChains.Add(chainGenerator.PerkChain);
            }
        }

        PerksTreeModel newTreeModel = new PerksTreeModel(perkChains);
        return newTreeModel;
    }
}
