using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//all information about a building that is not specific to a particular instance of a building
public abstract class BuildingInfo
{
    //the name of the building
    public static BuildingScriptableObject scriptableObject;

    //constructor delegate
    public static Func<BuildingModel> constructor;

}
