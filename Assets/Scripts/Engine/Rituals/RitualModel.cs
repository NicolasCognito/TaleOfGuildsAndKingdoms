using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RitualModel : IEntity
{
    //each ritual contains few slots to be filled with heroes or other Entites 
    //yet it should be defined in the child class separately

    //each ritual have clear method to unlock all slots and set their IEntity to null
    public abstract void Clear();

    //each ritual have method to check if all slots are filled and all conditions are met
    public abstract bool IsReady();
}
