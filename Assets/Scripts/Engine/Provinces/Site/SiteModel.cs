using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteModel : IEntity
{
    private List<BuildingEnum> _availableBuildings;

    private BuildingModel _building;

    private ProvinceModel _province;

    //methods

    //build something
    public void ConstructBuilding(BuildingEnum buildingType)
    {
        if (BuildingDictionary.dictionary.TryGetValue(buildingType, out BuildingInfo buildingInfo))
        {
            //call constructor delegate from BuildingInfo
            _building = BuildingInfo.constructor();
        }

        throw new ArgumentException($"BuildingEnum {buildingType} is not registered.");
    }
}
