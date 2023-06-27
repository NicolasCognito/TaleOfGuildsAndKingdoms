using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GamePhasesManager is a static class that manages the game phases
// should be singleton?
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
        // Get the global event queue
        eventQueue = EventQueueGlobal.Instance;

        

        // Example: Add events to the event queue based on player decisions or game state

        

        //merge events from all factions
        eventQueue.MergeQueues();

        //debug
        Debug.Log("About to execute events, count: " + eventQueue.events.Count);
        
        // Execute the events in the event queue
        eventQueue.ExecuteEvents();

        // Transition to the next phase if applicable
        // Example: Transition to the next round or end the game
    }
    
}
