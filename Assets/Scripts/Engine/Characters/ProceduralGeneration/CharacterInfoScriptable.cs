using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/CharacterInfo")]
public class CharacterInfoProfileScriptable: SerializedScriptableObject
{
    //contains decorative information about the character, such as name and image
    
    //list of possible first names
    [OdinSerialize]
    private List<string> FirstNames = new List<string>();

    //list of possible second names
    [OdinSerialize]
    private List<string> SecondNames = new List<string>();

    //list of possible images
    [OdinSerialize]
    private List<Sprite> Images = new List<Sprite>();

    //generate a character info model
    public CharacterInfoModel GenerateCharacterInfoModel()
    {
        //get random name
        string name = FirstNames[Random.Range(0, FirstNames.Count)];

        //get random second name
        string secondName = SecondNames[Random.Range(0, SecondNames.Count)];

        //get random image
        Sprite image = Images[Random.Range(0, Images.Count)];

        //return character info model
        return new CharacterInfoModel(name, secondName, image);
    }

}
