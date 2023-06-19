using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoModel
{
    //name, second name, and sprite
    public string Name { get; }

    public string SecondName { get; }

    public Sprite Sprite { get; }

    //constructor
    public CharacterInfoModel(string name, string secondName, Sprite sprite)
    {
        Name = name;
        SecondName = secondName;
        Sprite = sprite;
    }
}
