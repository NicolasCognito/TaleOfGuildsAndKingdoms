using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this interface is used to mark all entities that can be assigned to a company
public interface IUnit
{
    //property to get the strength of the unit
    int Strength { get; set;}
}
