using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;

[CreateAssetMenu(menuName = "Perks/Perk")]
public class PerkScriptable : SerializedScriptableObjectWithID
{
    //property PerkType is a wrapper for the ID
    public string PerkType { get { return uID; } set { uID = value; } }

    //Level of the perk in chain
    [Sirenix.OdinInspector.ReadOnly]
    public int Level;

    //cost of the perk in perk points
    public int Cost;

    //TODO: make it private
    [ListDrawerSettings]
    [OdinSerialize, ShowInInspector]
    public List<PerkCondition> Conditions = new List<PerkCondition>();

    public List<string> Tags;

    public bool ConditionsMet(CharacterModel character)
    {
        //check if the conditions are met
        foreach (PerkCondition condition in Conditions)
        {
            //check if the condition is met
            if (!condition.CheckCondition(character))
            {
                //return false
                return false;
            }
        }

        //return true
        return true;
    }

    private void OnValidate()
    {
        // Read the JSON file
        string json = File.ReadAllText("Assets/Scripts/GameData/Perks/PerkTags.json");

        // Parse the JSON file
        JObject jsonObject = JObject.Parse(json);
        JArray jsonTags = (JArray)jsonObject["tags"];
        List<string> tagsFromFile = jsonTags.ToObject<List<string>>();

        // Check if the tags in the PerkScriptable are listed in the file
        foreach (string tag in Tags)
        {
            if (!tagsFromFile.Contains(tag))
            {
                Debug.LogError("Tag " + tag + " in PerkScriptable " + PerkType + " is not listed in the file.");
            }
        }
    } 
}
