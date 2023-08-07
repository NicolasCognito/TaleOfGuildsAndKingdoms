using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this interface should be impleneted by any manager class that could plan usage of resources from inventory
public interface IResourceReservation
{
    //plans resource usage over time
    void ReserveResources(params object[] args);

    //free resources that have been planned but not used yet
    void FreeReservedResources(params object[] args);
}

