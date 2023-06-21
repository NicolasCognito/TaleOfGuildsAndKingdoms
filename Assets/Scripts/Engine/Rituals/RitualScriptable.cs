using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ritual", menuName = "Rituals/Ritual")]
public abstract class RitualScriptable : SerializedScriptableObjectWithID
{
    //list of slots
    public List<Slot<IEntity, RitualModel>> Slots { get; set; }
    public abstract bool Condition(params object[] args);

    public abstract void Execute(params object[] args);
}
