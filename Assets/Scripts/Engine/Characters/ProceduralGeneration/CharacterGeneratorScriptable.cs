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

    //stat generator class
    [System.Serializable]
    private class StatGenerator
    {
        //stat type
        public CharacterStatsEnum StatType;

        //min value
        public int MinValue;

        //max value
        public int MaxValue;
    }

    private class StatOutputModel : OutputModel
    {
        public CharacterStatModel Stat { get; }
        public StatGenerator Generator { get; }

        public StatOutputModel(CharacterStatModel stat, StatGenerator generator) 
            : base(generator.StatType.ToString(), generator.MaxValue - stat.Value + 1)
        {
            Stat = stat;
            Generator = generator;
        }
    }

    //list of stat generators
    [ListDrawerSettings]
    [OdinSerialize, ShowInInspector]
    private List<StatGenerator> StatGenerators = new List<StatGenerator>();

    //list of names and second names
    [ListDrawerSettings]
    [OdinSerialize, ShowInInspector]
    public List<string> Names = new List<string>();

    [ListDrawerSettings]
    [OdinSerialize, ShowInInspector]
    public List<string> SecondNames = new List<string>();

    //reference to the PerkTreeGeneratorScriptable
    public PerkTreeGeneratorScriptable PerkTreeGenerator;

    //generation process
    public CharacterModel GenerateCharacter()
    {
        //let's roll the attribute points
        int attributePoints = Random.Range(AttributePointsMin, AttributePointsMax);

        //set all stats to minimum value then distribute the points pseudo-randomly
        List<CharacterStatModel> stats = new List<CharacterStatModel>();

        //iterate through the stat generators
        foreach (StatGenerator statGenerator in StatGenerators)
        {
            //create a new stat model
            CharacterStatModel stat = new CharacterStatModel();

            //set the stat type
            stat.StatType = statGenerator.StatType;

            //set the value to minimum
            stat.Value = statGenerator.MinValue;

            //add the stat to the list
            stats.Add(stat);
        }

        // Create a list of output models based on stats and generators
        List<OutputModel> outputs = new List<OutputModel>();
        foreach (StatGenerator statGenerator in StatGenerators)
        {
            // Assuming you have a GetStat method to get a stat model from the list by its type
            CharacterStatModel stat = GetStat(stats, statGenerator.StatType);

            // Create a new output model for this stat and generator
            outputs.Add(new StatOutputModel(stat, statGenerator));
        }

        while (attributePoints > 0)
        {
            // Update probabilities
            foreach (OutputModel output in outputs)
            {
                StatOutputModel statOutput = output as StatOutputModel;
                statOutput.Probability = statOutput.Generator.MaxValue - statOutput.Stat.Value + 1;
            }

            // Make a weighted random selection from the output models
            StatOutputModel selectedOutput = (StatOutputModel)SaveThrow.Throw(outputs);

            // Increase the value of the selected stat
            selectedOutput.Stat.Value++;

            // Decrement attribute points
            attributePoints--;
        }

        //once the stats are generated, let's generate the perks
        //call corresponding method from the PerkTreeGeneratorScriptable
        PerksTreeModel perksTree = PerkTreeGenerator.GeneratePerkTreeModel(this);

        //create a new character model
        CharacterModel character = new CharacterModel(perksTree, stats);

        //return the character
        return character;
    }

    //function to roll specific perk chain and 

    // Function to get a stat from the list by its type
    CharacterStatModel GetStat(List<CharacterStatModel> stats, CharacterStatsEnum type)
    {
        foreach (CharacterStatModel stat in stats)
        {
            if (stat.StatType == type)
            {
                return stat;
            }
        }

        return null; // Return null if no stat of the given type is found
    }


    //on validate, make sure that the min values are not greater than the max values and all the values are positive
    //also, make sure all 6 main attributes provided
    
    private void OnValidate()
    {

    }

}
