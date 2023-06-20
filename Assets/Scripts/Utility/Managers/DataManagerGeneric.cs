using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager<T> where T : SerializedScriptableObjectWithID
{
    private Dictionary<string, T> dataDictionary = new Dictionary<string, T>();

    public void Initialize(IEnumerable<T> dataItems)
    {
        foreach (var item in dataItems)
        {
            if (!dataDictionary.ContainsKey(item.uID))
            {
                dataDictionary.Add(item.uID, item);
            }
            else
            {
                Debug.LogWarning($"Duplicate ID found: {item.uID}");
            }
        }
    }

    public T GetData(string id)
    {
        if (dataDictionary.TryGetValue(id, out T data))
        {
            return data;
        }
        else
        {
            Debug.LogWarning($"Data with ID {id} not found");
            return null;
        }
    }
}
