using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is temporary and will be removed
//it is used to test the turn and event system
public class GameTemporary : MonoBehaviour
{

    void Start()
    {
        //create first guild
        GuildModel guild1 = new GuildModel("Battle Trolls Clan");
        //create second guild
        GuildModel guild2 = new GuildModel("The Order of the Holy Light");

        //call test event
        guild1.TestEventQueue();
        guild2.TestEventQueue();
        guild2.TestEventQueue();

        //test recipe convertor
        InventoryModel inv = TestRecipe(guild1);

        //for each resource in inventory, display it
        foreach (ResourceModel resource in inv.Resources)
        {
            Debug.Log("Resource: " + resource.resourceType + " " + resource.quality + " " + resource.amount);
        }

        //same for delta resources
        foreach (ResourceModel resource in inv.DeltaResources)
        {
            Debug.Log("Delta resource: " + resource.resourceType + " " + resource.quality + " " + resource.amount);
        }

        //start active phase
        GamePhasesManager.StartActivePhase();

        //for each resource in inventory, display it
        foreach (ResourceModel resource in inv.Resources)
        {
            Debug.Log("Resource: " + resource.resourceType + " " + resource.quality + " " + resource.amount);
        }

        //same for delta resources
        foreach (ResourceModel resource in inv.DeltaResources)
        {
            Debug.Log("Delta resource: " + resource.resourceType + " " + resource.quality + " " + resource.amount);
        }
    }

    //test recipe convertor
    InventoryModel TestRecipe(GuildModel guild)
    {
        //create new inventory
        InventoryModel inventory = new InventoryModel(guild);

        //add plumbum to inventory
        inventory.AddResource(new ResourceModel("Iron","High", 100), false);

        //create new laborer pool
        LaborPool laborPool = new LaborPool();

        //add laborer to laborer pool
        laborPool.AddLaborer(new LaborerModel("basic"));

        ManagerController managerController = ManagerController.Instance;

        //get recipe PlumbumToAurum from datamanager
        RecipeScriptableObject recipe = ManagerController.RecipeDataManager.GetData("IronToGold");

        //create new recipe event
        EventRecipeModel recipeEvent = new EventRecipeModel(1, recipe, inventory, laborPool, 10);

        guild.EventQueue.AddEvent(recipeEvent);

        //debug log
        Debug.Log("Recipe event created");

        //return inventory
        return inventory;
    }
}
