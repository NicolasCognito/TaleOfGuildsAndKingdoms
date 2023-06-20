using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class SerializedScriptableObjectWithID : SerializedScriptableObject
{
    //string to store the ID of perk
    [ShowInInspector]
    private string _uID;

    //property for the ID (getter/setter)
    
    public string uID { get { return _uID; } set { _uID = value; } }
}