using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSlot
{
    //reference to the specific order scriptable
    public UnitSlotSriptable UnitScriptable { get; private set; }

    //containment (nullable UnitModel)
    public UnitModel ContainedUnit { get; private set; }

    public UnitSlot(UnitSlotSriptable unitScriptable)
    {
        UnitScriptable = unitScriptable;

        //by default, no unit is assigned
        ContainedUnit = null;
    }

    //assign a unit to this slot
    public void AssignUnit(UnitModel unitModel)
    {
        //verify if the unit can be assigned to this slot
        if (CanAssignUnit(unitModel))
        {
            //assign the unit
            ContainedUnit = unitModel;
        }
        else
        {
            //log
            Debug.Log("Unit cannot be assigned to this slot");
        }
    }

    //remove the unit from this slot
    public void RemoveUnit()
    {
        //remove the unit
        ContainedUnit = null;
    }

    //verify if the unit can be assigned to this slot
    public bool CanAssignUnit(UnitModel unitModel)
    {
        //get all tag lists from the unit slot scriptable
        List<string> allowedTags = UnitScriptable.AllowedTags;
        List<string> disallowedTags = UnitScriptable.DisallowedTags;
        List<string> necessaryTags = UnitScriptable.NecessaryTags;

        //check if the unit has all necessary tags
        foreach (string necessaryTag in necessaryTags)
        {
            //if the unit doesn't have the necessary tag, return false
            if (!unitModel.Tags.Contains(necessaryTag))
            {
                return false;
            }
        }

        //check if the unit has any disallowed tags
        foreach (string disallowedTag in disallowedTags)
        {
            //if the unit has a disallowed tag, return false
            if (unitModel.Tags.Contains(disallowedTag))
            {
                return false;
            }
        }

        //check if the unit has any allowed tags
        if (allowedTags.Count > 0)
        {
            //check if the unit has any allowed tags
            foreach (string allowedTag in allowedTags)
            {
                //if the unit has an allowed tag, return true
                if (unitModel.Tags.Contains(allowedTag))
                {
                    return true;
                }
            }

            //if the unit doesn't have any allowed tags, return false
            return false;
        }

        //we never should get to this point, throw an error
        throw new System.Exception("UnitSlot.CanAssignUnit() reached an unreachable point");

    }

}
