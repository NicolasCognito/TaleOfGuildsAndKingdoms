using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alchemy Recipe", menuName = "Alchemy Recipe")]
public class RecipeScriptableObject : ScriptableObject
{
    public string Name;
    public List<ResourceSlot> inputResources = new List<ResourceSlot>();
    public List<ResourceSlot> outputResources = new List<ResourceSlot>();
}
