using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for now there is only 6 must-have attributes
//new can't be added nor removed
public class CharacterAttributeSetModel
{
    // List of valid attributes
    public static readonly List<string> validAttributes = new List<string> { "strength", "agility", "constitution", "intelligence", "wisdom", "charisma" };

    //attributes
    public CharacterAttribute Strength { get; private set; }
    public CharacterAttribute Dexterity { get; private set; }
    public CharacterAttribute Constitution { get; private set; }
    public CharacterAttribute Intelligence { get; private set; }
    public CharacterAttribute Wisdom { get; private set; }
    public CharacterAttribute Charisma { get; private set; }

    public Dictionary<string, CharacterAttribute> Attributes { get; private set; }

    //constructor
    public CharacterAttributeSetModel(int str, int dex, int con, int intel, int wis, int cha)
    {
        Strength = new CharacterAttribute("strength", str);
        Dexterity = new CharacterAttribute("dexterity", dex);
        Constitution = new CharacterAttribute("constitution", con);
        Intelligence = new CharacterAttribute("intelligence", intel);
        Wisdom = new CharacterAttribute("wisdom", wis);
        Charisma = new CharacterAttribute("charisma", cha);

        Attributes = new Dictionary<string, CharacterAttribute>()
        {
            { "strength", Strength },
            { "dexterity", Dexterity },
            { "constitution", Constitution },
            { "intelligence", Intelligence },
            { "wisdom", Wisdom },
            { "charisma", Charisma }
        };
    }
}
