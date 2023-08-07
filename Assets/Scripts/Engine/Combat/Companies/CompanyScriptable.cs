using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyScriptable : SerializedScriptableObjectWithID
{
    //company name (uID wrapper)
    public string CompanyType { get { return uID; } set { uID = value; } }

    //slots for units
    public List<UnitSlotSriptable> unitSlots = new List<UnitSlotSriptable>();

    //basic capacity of the company
    public int defaultCapacity;

    //basic initiative of the company
    public int defaultInitiative;

    //basic tactical proficiency of the company
    public int defaultTacticalProficiency;


}
