using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this one can be created without scriptable object (or with it, if custom logic is needed)
public class EventRecipeModel : EventModel
{
    private RecipeScriptableObject recipe;
    private InventoryModel inventory;
    private LaborPool laborPool;
    private int stacks;

    public EventRecipeModel(int priority, RecipeScriptableObject recipe, InventoryModel inventory, LaborPool laborPool, int stacks)
        : base(priority, null, null)
    {
        this.recipe = recipe;
        this.inventory = inventory;
        this.laborPool = laborPool;
        this.stacks = stacks;

        //replace condition delegate with always true (all checks are done in the execute delegate)
        Condition = (args) => true;

        Execute = (args) => RecipeExecution(args);
    }

    public void RecipeExecution(params object[] args)
    {
        //Create a new instance of the RecipeExecutionManager
        RecipeExecutionManager recipeExecutionManager = new RecipeExecutionManager(inventory, laborPool);

        //Execute the recipe
        recipeExecutionManager.ExecuteRecipe(recipe, stacks);
    }
}
