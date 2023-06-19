using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyModel
{
    //only actual value company has is it's roster
    public List<IUnit> roster = new List<IUnit>();

    //property to get the strength of the company
    public int Strength
    {
        get
        {
            //variable to store the strength of the company
            int strength = 0;

            //loop through all the units in the roster
            foreach (IUnit unit in roster)
            {
                //add the strength of the unit to the strength of the company
                strength += unit.Strength;
            }

            //return the strength of the company
            return strength;
        }
    }

    
}
