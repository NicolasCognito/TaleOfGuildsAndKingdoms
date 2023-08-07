using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this interface is used to mark all entities that can be assigned to a company as a UnitModel
public interface IUnit
{
    //property to get the strength of the unit
    int Strength { get; set;}

    //morale of the unit
    int Morale { get; set; }

    //initiative of the unit
    int Initiative { get; set; }

    //tactical capacity of the unit
    int TacticalCapacity { get; set; }

    //survive/decease values
    int SurvivalRate { get; set; }
    int DeceaseRate { get; set; }

    //death flag (O mae wa mou shindeiru! NANI?!)
    bool IsDead { get; set; }
    
    //list of tags (string) that describe the unit
    List<string> Tags { get; set; }

    //set of attributes
    CharacterAttributeSetModel Attributes { get; set; }
}
