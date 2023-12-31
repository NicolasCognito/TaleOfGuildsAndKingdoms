using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Building", order = 1)]
public class BuildingScriptableObject : ScriptableObject
{
    public string Name;

    public List<string> AssociatedCards;
}
