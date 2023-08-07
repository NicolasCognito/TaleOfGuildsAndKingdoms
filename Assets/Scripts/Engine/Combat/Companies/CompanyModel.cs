using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyModel
{
    //scriptable object that defines the company
    public CompanyScriptable companyScriptable;

    //only actual value company has is it's roster, represented by a list of unit slots
    public List<UnitSlot> roster = new List<UnitSlot>();

    // Property to get the overall power of the company
    public int Power { get; private set; }

    //property to get the offensive capabilities of the company
    public int Strength { get; private set; }

    // Property to get the defensive capabilites of the company
    public int Protection { get; private set; }

    //property to get the initiative of the company
    public int Initiative { get; private set; }

    //property to get the capacity of the company
    public int maxCapacity { get; private set; }

    //property to get the current capacity of the company
    public int currentCapacity { get; private set; }

    //property to get tactical proficiency of the company
    public int maxTacticalProficiency { get; private set; }

    //property to get the current tactical proficiency of the company
    public int currentTacticalProficiency { get; private set; }

    //property to get the resolve of the company
    public BalancingStatModel Resolve { get; private set; }

    //constructor (from scriptable)
    public CompanyModel(CompanyScriptable companyScriptable)
    {
        //set the scriptable
        this.companyScriptable = companyScriptable;

        //set the default max capacity
        maxCapacity = companyScriptable.defaultCapacity;

        //set the initiative
        Initiative = companyScriptable.defaultInitiative;

        //set the tactical proficiency
        maxTacticalProficiency = companyScriptable.defaultTacticalProficiency;

        //set the strength
        Strength = 0;

        //set the current capacity
        currentCapacity = 0;

        //set the current tactical proficiency
        currentTacticalProficiency = 0;

        //set the resolve
        Resolve = new BalancingStatModel(0, 0, 0);

        //add all unit slots from the roster
        foreach(UnitSlotSriptable unitSlotSriptable in companyScriptable.unitSlots)
        {
            //create a new unit slot
            UnitSlot unitSlot = new UnitSlot(unitSlotSriptable);

            //add the unit slot to the roster
            roster.Add(unitSlot);
        }
    }
}
