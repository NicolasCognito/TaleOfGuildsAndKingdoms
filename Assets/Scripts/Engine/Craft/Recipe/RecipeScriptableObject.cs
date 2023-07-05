using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

// This class defines the data structure for a recipe, which includes the recipe name, tier step,
// a list of RecipeConvertor objects, and a list of LaborCostModel objects.
[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class RecipeScriptableObject : SerializedScriptableObjectWithID
{
    //name of the recipe (id)
    public string recipeName;

    //tier step 
    public int tierStep;

    //max tier
    public int maxTier;

    //list of convertors
    public List<RecipeConvertor> convertors = new List<RecipeConvertor>();

    //list of labor costs
    public List<LaborCostModel> laborCosts = new List<LaborCostModel>();

    //get convertor for tier
    public RecipeConvertor GetConvertorForTier(int tier)
    {
        //check if convertor exists for tier
        if (convertors.Count > tier && tier >= 0)
        {
            //return convertor
            return convertors[tier];
        }
        else
        {
            // If the tier is negative, return the first convertor
            if (tier < 0)
            {
                return convertors[0];
            }
            // If the tier is out of range, return the last convertor
            else
            {
                return convertors[convertors.Count - 1];
            }
        }
    }

    //get labor cost for tier
    public LaborCostModel GetLaborCostForTier(int tier)
    {
        //check if labor cost exists for tier
        if (laborCosts.Count > tier && tier >= 0)
        {
            //return labor cost
            return laborCosts[tier];
        }
        else
        {
            // If the tier is negative, return the first labor cost
            if (tier < 0)
            {
                return laborCosts[0];
            }
            // If the tier is out of range, return the last labor cost
            else
            {
                return laborCosts[laborCosts.Count - 1];
            }
        }
    }
}
