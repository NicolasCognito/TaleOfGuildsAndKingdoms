using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is temporary and will be removed
//it is used to test the turn and event system
public class GameTemporary : MonoBehaviour
{

    void Start()
    {
        //create first guild
        GuildModel guild1 = new GuildModel("Battle Trolls Clan");
        //create second guild
        GuildModel guild2 = new GuildModel("The Order of the Holy Light");

        //call test event
        guild1.TestEventQueue();
        guild2.TestEventQueue();
        guild2.TestEventQueue();

        //start active phase
        GamePhasesManager.StartActivePhase();
       
    }
}
