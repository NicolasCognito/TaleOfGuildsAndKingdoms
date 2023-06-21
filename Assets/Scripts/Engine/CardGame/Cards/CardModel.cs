using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardModel : IEntity
{
    //function to check if the card is playable
    public abstract bool IsPlayable();
    
    //Evaluation is used to determine the possibility of the card to be played
    public abstract int Evaluation();

    //Execute is used to apply the card's effect
    public abstract void Execute();

    //reset the card on the end of the turn
    public abstract void Reset();
}
