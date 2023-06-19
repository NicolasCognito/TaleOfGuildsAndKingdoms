using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBuildingInfo : BuildingInfo
{
    static FarmBuildingInfo()
    {
        //set delegate to constructor
        BuildingInfo.constructor = () => new FarmBuildingModel();

        //set reference to scriptable object
        BuildingInfo.scriptableObject = (BuildingScriptableObject)Resources.Load("Assets/Scripts/GameData/Buildings/Farm/FarmScriptable.asset");
    }
}
