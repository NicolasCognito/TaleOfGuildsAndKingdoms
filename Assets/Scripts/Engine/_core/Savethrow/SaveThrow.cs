using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveThrow
{
    public static OutputModel Throw(List<OutputModel> outputs)
    {
        //exclude outputs with probability 0 or less
        outputs.RemoveAll(output => output.Probability <= 0);

        int totalProbability = 0;
        foreach (OutputModel output in outputs)
        {
            totalProbability += output.Probability;
        }

        int random = Random.Range(0, totalProbability);
        int currentProbability = 0;
        foreach (OutputModel output in outputs)
        {
            currentProbability += output.Probability;
            if (random < currentProbability)
            {
                return output;
            }
        }    
        return null;
    }

    //same as above with integers instead of OutputModels
    public static string Throw(Dictionary<string, int> outputs)
    {
        //exclude outputs with probability 0 or less from the dictionary
        foreach (string key in outputs.Keys)
        {
            if (outputs[key] <= 0)
            {
                outputs.Remove(key);
            }
        }

        int totalProbability = 0;
        foreach (string key in outputs.Keys)
        {
            totalProbability += outputs[key];
        }

        int random = Random.Range(0, totalProbability);
        int currentProbability = 0;
        foreach (string key in outputs.Keys)
        {
            currentProbability += outputs[key];
            if (random < currentProbability)
            {
                //return the string of the output
                return key;

            }
        }
        
        //if no output was selected, return -1
        return null;
    }
}
