using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController
{
    //singleton
    private static ManagerController _instance;

    public static ManagerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ManagerController();
            }

            return _instance;
        }
    }

    //data managers
    public static DataManager<PerkChainScriptable> PerkChainDataManager { get; private set; }

    public static DataManager<RecipeScriptableObject> RecipeDataManager { get; private set; }

    public static DataManager<CombinationModel> CombinationsManager { get; private set; }

    //constructor
    private ManagerController()
    {
        //initialize data managers
        PerkChainDataManager = new DataManager<PerkChainScriptable>("Perks");

        RecipeDataManager = new DataManager<RecipeScriptableObject>("Recipes");

        CombinationsManager = new DataManager<CombinationModel>("Combinations");
    }


}
