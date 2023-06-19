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
}
