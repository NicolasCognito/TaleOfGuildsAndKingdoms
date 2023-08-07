using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//there is 6 must-have attributes for each character
//strength, agility, constitution, intelligence, wisdom, charisma
public class CharacterAttribute
{
    //type
    public string AttributeType;

    //value
    public int Value;

    //constructor
    public CharacterAttribute(string type, int value)
    {
        AttributeType = type;
        Value = value;
    }
}
