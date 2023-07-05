using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ManagerController managerController = ManagerController.Instance;

        //get the perk chain data
        PerkChainScriptable perkChainData = ManagerController.PerkChainDataManager.GetData("Warrior");

        //if null, send a warning
        if (perkChainData == null)
        {
            Debug.LogWarning("Perk chain data is null");
        }
        else
        {
            //if not null, print the data
            Debug.Log("Perk chain data: " + perkChainData.uID);
        }

        //get the recipe data
        RecipeScriptableObject recipeData = ManagerController.RecipeDataManager.GetData("IronToGold");

        //if null, send a warning
        if (recipeData == null)
        {
            Debug.LogWarning("Recipe data is null");
        }
        else
        {
            //if not null, print the data
            Debug.Log("Recipe data: " + recipeData.uID);
        }
    }

}
