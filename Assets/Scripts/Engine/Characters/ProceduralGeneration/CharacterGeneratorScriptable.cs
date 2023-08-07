using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

//scriptable object to store the character generation data
//vary from race to race
public class CharacterGeneratorScriptable : SerializedScriptableObject
{
    //attribute points min and max
    private int AttributePointsMin;
    private int AttributePointsMax;

    //For now, it never used, character just always have all perks he rolled
    /*
    //perk chains min and max
    private int PerkChainsMin;
    private int PerkChainsMax;

    //individual perks min and max
    private int PerksMin;
    private int PerksMax;
    */

    //Attribute generator class
    [System.Serializable]
    private class AttributeGenerator
    {
        //Attribute type
        public string AttributeType;

        //min value
        public int MinValue;

        //max value
        public int MaxValue;
    }

    private class AttributeOutputModel : OutputModel
    {
        public CharacterAttribute Attribute { get; }
        public AttributeGenerator Generator { get; }

        public AttributeOutputModel(CharacterAttribute attribute, AttributeGenerator generator) 
            : base(generator.AttributeType.ToString(), generator.MaxValue - attribute.Value + 1)
        {
            Attribute = attribute;
            Generator = generator;
        }
    }

    //list of stat generators
    [ListDrawerSettings]
    [OdinSerialize, ShowInInspector]
    private List<AttributeGenerator> AttributeGenerators = new List<AttributeGenerator>();

    //reference to the PerkTreeGeneratorScriptable
    public PerkTreeGeneratorScriptable PerkTreeGenerator;

    //generation process
    public CharacterModel GenerateCharacter()
    {
        GenerateAttributes();
        // Once the attributes are generated, let's generate the perks
        // Call corresponding method from the PerkTreeGeneratorScriptable
        PerksTreeModel perksTree = PerkTreeGenerator.GeneratePerkTreeModel(this);

        // Create a new character model
        //I'm using placeholder in the constructor for now
        CharacterModel character = new CharacterModel(perksTree);

        // Return the character
        return character;
    }

    private void GenerateAttributes()
    {
        //this code should be refactored asap, for now I commented it to have a reference for the future
        //attribute generator simply put the attributes to 8 by now
        /* // Let's roll the attribute points
        int attributePoints = Random.Range(AttributePointsMin, AttributePointsMax);

        // Set all attributes to minimum value then distribute the points pseudo-randomly
        List<CharacterAttribute> attributes = new List<CharacterAttribute>();

        // Iterate through the attribute generators
        foreach (AttributeGenerator attributeGenerator in AttributeGenerators)
        {
            // Set the attribute type
            attribute.AttributeType = attributeGenerator.AttributeType;

            // Set the value to minimum
            attribute.Value = attributeGenerator.MinValue;

            // Add the attribute to the list
            attributes.Add(attribute);
        }

        // Create a list of output models based on attributes and generators
        List<OutputModel> outputs = new List<OutputModel>();
        foreach (AttributeGenerator attributeGenerator in AttributeGenerators)
        {
            // Assuming you have a GetAttribute method to get an attribute model from the list by its type
            CharacterAttribute attribute = GetAttribute(attributes, attributeGenerator.AttributeType);

            // Create a new output model for this attribute and generator
            outputs.Add(new AttributeOutputModel(attribute, attributeGenerator));
        }

        while (attributePoints > 0)
        {
            // Update probabilities
            foreach (OutputModel output in outputs)
            {
                AttributeOutputModel attributeOutput = output as AttributeOutputModel;
                attributeOutput.Probability = attributeOutput.Generator.MaxValue - attributeOutput.Attribute.Value + 1;
            }

            // Make a weighted random selection from the output models
            AttributeOutputModel selectedOutput = (AttributeOutputModel)SaveThrow.Throw(outputs);

            // Increase the value of the selected attribute
            selectedOutput.Attribute.Value++;

            // Decrement attribute points
            attributePoints--;
        } */

    }

    // Function to get an attribute from the list by its type
    CharacterAttribute GetAttribute(List<CharacterAttribute> attributes, string type)
    {
        foreach (CharacterAttribute attribute in attributes)
        {
            if (attribute.AttributeType == type)
            {
                return attribute;
            }
        }

        // If no attribute was found, throw an exception
        throw new System.Exception("Attribute not found: " + type);
    }


    //on validate, make sure that the min values are not greater than the max values and all the values are positive
    //also, make sure all 6 main attributes provided
    
    private void OnValidate()
    {

    }

}
