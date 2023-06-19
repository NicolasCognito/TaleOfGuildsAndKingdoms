using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBuildingModel : BuildingModel
{
    //set default tags to FoodProduction
    public override List<BuildingTag> DefaultTags { get; set; }
    public override bool ConstructionCondition()
    {
        //could be built regardless of the province's terrain
        return true;
    }

    public override bool OperationalCondition()
    {
        //for now, the farm is always operational, rework this later after implementing the tag system
        return true;
    }
}
