using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CycleModel
{
    //cycle is a set of cards
    public List<CardModel> cards = new List<CardModel>();

    //property to stop the cycle for the rest of the turn
    public bool Stop { get; set; }


    //play cycle method
    public void Play()
    {
        //find playable card with the highest evaluation
        //TODO: replace with a more sophisticated algorithm
        CardModel card = cards[0];
        foreach (CardModel c in cards)
        {
            if (c.IsPlayable() && c.Evaluation() > card.Evaluation())
            { 
                card = c;
            }
        }

        //play the card
        card.Execute();

        //if cycle is not stopped
        if (!Stop)
        {
            //check for playable cards
            bool playable = false;
            foreach (CardModel c in cards)
            {
                if (c.IsPlayable())
                {
                    playable = true;
                    break;
                }
            }

            //if there are playable cards
            if (playable)
            {
                //play the cycle again
                Play();
            }
        }

    }
    
}
