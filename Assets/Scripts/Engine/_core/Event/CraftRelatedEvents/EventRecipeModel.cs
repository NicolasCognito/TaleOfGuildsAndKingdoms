using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this one can be created without scriptable object (or with it, if custom logic is needed)
public class EventRecipeModel : EventModel
{
    private RecipeExecutionManager executionManager;

    public EventRecipeModel(int priority, RecipeExecutionManager executionManager)
        : base(priority, null, null)
    {
        this.executionManager = executionManager;

        //replace condition delegate with always true (all checks are done in the execute delegate)
        Condition = (args) => true;

        Execute = (args) => RecipeExecution(args);
    }

    public void RecipeExecution(params object[] args)
    {
        // Call the ExecuteRecipe method of the executionManager
        executionManager.ExecuteRecipe();
    }
}
