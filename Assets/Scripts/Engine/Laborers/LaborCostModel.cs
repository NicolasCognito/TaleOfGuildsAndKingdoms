using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class LaborCostModel
{
    //list of laborer slots
    [ListDrawerSettings(ShowItemCount = true, DraggableItems = true, ShowFoldout = true)]
    public List<LaborerSlotModel> laborerSlots = new List<LaborerSlotModel>();
}
