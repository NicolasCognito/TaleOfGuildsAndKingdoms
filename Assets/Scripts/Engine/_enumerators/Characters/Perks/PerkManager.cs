using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkManager
{
    // Singleton instance
    public static PerkManager Instance { get; private set; }

    // Dictionary to store PerkScriptable objects
    private Dictionary<string, PerkScriptable> perkDictionary;

    // Constructor
    private PerkManager()
    {
        perkDictionary = new Dictionary<string, PerkScriptable>();
    }

    // Method to add a PerkScriptable object to the dictionary
    public void AddPerk(PerkScriptable perk)
    {
        if (!perkDictionary.ContainsKey(perk.PerkType))
        {
            perkDictionary.Add(perk.PerkType, perk);
        }
    }

    // Method to get a PerkScriptable object from the dictionary
    public PerkScriptable GetPerk(string perkID)
    {
        if (perkDictionary.ContainsKey(perkID))
        {
            return perkDictionary[perkID];
        }
        return null;
    }

    // Method to initialize the Singleton instance
    public static void Initialize()
    {
        if (Instance == null)
        {
            Instance = new PerkManager();
        }
    }
}