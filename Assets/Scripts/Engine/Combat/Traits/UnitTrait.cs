using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//trait that can be possessed by a unit
public class UnitTrait : SerializedScriptableObjectWithID
{
    //trait name
    public string TraitName { get => uID;}

}
