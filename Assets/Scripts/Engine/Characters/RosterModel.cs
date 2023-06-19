using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosterModel
{
    //max roster size
    private int maxRosterSize;

    //list of heroes
    private List<CharacterModel> heroes;

    //add hero to roster
    public void AddHero(CharacterModel hero)
    {
        //add hero to roster
        heroes.Add(hero);
    }
}
