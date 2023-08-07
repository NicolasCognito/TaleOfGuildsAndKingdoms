using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//trait that can be possessed by a company
public class CompanyTrait : SerializedScriptableObjectWithID
{
    //trait name
    public string TraitName { get => uID; set => uID = value; }
}
