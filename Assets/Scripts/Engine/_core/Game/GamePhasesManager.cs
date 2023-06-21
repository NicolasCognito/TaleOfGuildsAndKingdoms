using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePhasesManager
{
    private static EventQueueGlobal eventQueue;

    public static void StartPlanningPhase()
    {
        // Perform any necessary initialization for the planning phase
        
        // Example: Prompt players for decisions or setup game state
        
        // Transition to the active phase after the planning phase is complete
        StartActivePhase();
    }

    public static void StartActivePhase()
    {
        // Perform any necessary initialization for the active phase

        // Example: Create an instance of EventQueue
        eventQueue = new EventQueueGlobal();

        // Example: Add events to the event queue based on player decisions or game state
        
        // Execute the events in the event queue
        eventQueue.ExecuteEvents();

        // Transition to the next phase if applicable
        // Example: Transition to the next round or end the game
    }
    
}
