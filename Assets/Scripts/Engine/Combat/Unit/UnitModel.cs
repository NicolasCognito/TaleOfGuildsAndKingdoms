using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel : IUnit
{
    private int strength;
    private int morale;
    private int initiative;
    private int tacticalCapacity;
    private int survive;
    private int decease;
    private bool isDead;
    private List<string> tags;
    private CharacterAttributeSetModel attributes;

    public UnitModel(int strength, int morale, int initiative, int tacticalCapacity, int survive, int decease, bool isDead, List<string> tags, CharacterAttributeSetModel attributes)
    {
        this.strength = strength;
        this.morale = morale;
        this.initiative = initiative;
        this.tacticalCapacity = tacticalCapacity;
        this.survive = survive;
        this.decease = decease;
        this.isDead = isDead;
        this.tags = new List<string>(tags);
        this.attributes = attributes;
    }

    public int Strength { get => strength; set => strength = value; }
    public int Morale { get => morale; set => morale = value; }
    public int Initiative { get => initiative; set => initiative = value; }
    public int TacticalCapacity { get => tacticalCapacity; set => tacticalCapacity = value; }
    public int SurvivalRate { get => survive; set => survive = value; }
    public int DeceaseRate { get => decease; set => decease = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public List<string> Tags { get => tags; set => tags = new List<string>(value); }
    public CharacterAttributeSetModel Attributes { get => attributes; set => attributes = value; }
}
