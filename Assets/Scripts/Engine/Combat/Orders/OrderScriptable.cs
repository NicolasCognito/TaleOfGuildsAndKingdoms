using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//order for a company to execute
public abstract class OrderScriptable : SerializedScriptableObjectWithID
{
    //order name
    public string OrderName { get => uID; set => uID = value; } 
}
