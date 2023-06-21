using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;

[CreateAssetMenu(menuName = "Perks/Perk")]
public class PerkScriptable : SerializedScriptableObject
{
    //ID of the perk
    private string uID;

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

    

    private void OnValidate()
    {
        // Read the JSON file
        string json = File.ReadAllText("Assets/Resources/Perks/PerkTags.json");

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
