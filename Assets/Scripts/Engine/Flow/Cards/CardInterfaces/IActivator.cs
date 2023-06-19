using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this interface is used for cards that could be manually activated or deactivated by the player
public interface IActivator
{
    //properties 
    bool CardIsActive { get; protected set;}

    //methods
    //this method is used to toggle the state of the card
    void Toggle()
    {
        //change the state of IsActive to the opposite
        CardIsActive = !CardIsActive;
    }

    //this method is used to check if the activator behaviour should be applied
    bool ActivatorCondition();
}
