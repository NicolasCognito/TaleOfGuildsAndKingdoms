using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is temporary and will be removed
//it is used to test the turn and event system
public class GameTemporary : MonoBehaviour
{
    static InventoryModel inventory;

    void Start()
    {
        //create first guild
        GuildModel guild1 = new GuildModel("Battle Trolls Clan");
        //create second guild
        GuildModel guild2 = new GuildModel("The Order of the Holy Light");

        //inventory = new InventoryModel(guild1);

        //call test event
        guild1.TestEventQueue();
        guild2.TestEventQueue();
        guild2.TestEventQueue();

        //test recipe convertor
        InventoryModel inv = TestRecipe(guild1);
        //start active phase
        GamePhasesManager.StartActivePhase();

        int iron = inv.GetResourceAmount("Iron", "High");
        int gold = inv.GetResourceAmount("Gold", "Low");

        //debbug resource amounts
        Debug.Log("Iron amount: " + iron);
        Debug.Log("Gold amount: " + gold);
    }

    //test recipe convertor
    InventoryModel TestRecipe(GuildModel guild)
    {
        //create new inventory
        InventoryModel inventory = new InventoryModel(guild);

        //add plumbum to inventory
        inventory.AddResource(new ResourceModel("Iron","High", 100), false);

        Debug.Log("Added Iron to inventory.");

        int iron = inventory.GetResourceAmount("Iron", "High");
        int gold = inventory.GetResourceAmount("Gold", "Low");

        //debbug resource amounts
        Debug.Log("Iron amount: " + iron);
        Debug.Log("Gold amount: " + gold);

        //create new laborer pool
        LaborPool laborPool = new LaborPool();

        //add laborer to laborer pool
        laborPool.AddLaborer(new LaborerModel("basic"));

        Debug.Log("Added laborer to labor pool.");

        ManagerController managerController = ManagerController.Instance;

        //get recipe PlumbumToAurum from datamanager
        RecipeScriptableObject recipe = ManagerController.RecipeDataManager.GetData("IronToGold");

        Debug.Log("Retrieved IronToGold recipe from data manager.");

        //create new execution
        RecipeExecutionManager recipeExecutionManager = new(inventory, laborPool, recipe);

        //create new recipe event
        EventRecipeModel recipeEvent = new EventRecipeModel(0, recipeExecutionManager);

        guild.EventQueue.AddEvent(recipeEvent);

        recipeExecutionManager.IncrementStacks(2);

        Debug.Log("Recipe event created and added to guild's event queue.");

        //return inventory
        return inventory;
    }

}
