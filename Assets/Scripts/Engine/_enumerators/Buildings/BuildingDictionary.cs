using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingDictionary
{
    public static readonly Dictionary<BuildingEnum, BuildingInfo> dictionary = new Dictionary<BuildingEnum, BuildingInfo>
    {
        { BuildingEnum.Farm, new FarmBuildingInfo()}
    };
}
