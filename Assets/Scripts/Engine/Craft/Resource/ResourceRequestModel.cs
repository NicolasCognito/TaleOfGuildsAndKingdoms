using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRequestModel 
{
    public class IndividualResourceRequestModel {
        public string ResourceType {get; set;}
        public string Quality {get; set;}
        public int Amount {get; set;}
    }

    public List<IndividualResourceRequestModel> ResourceRequests {get; set;}

    public ResourceRequestModel(RecipeScriptableObject recipe, int stacks, int tier)
    {
        ResourceRequests = new List<IndividualResourceRequestModel>();

        // Get the convertor for the specified tier
        RecipeConvertor convertor = recipe.GetConvertorForTier(tier);

        foreach (var resource in convertor.inputResources)
        {
            ResourceRequests.Add(new IndividualResourceRequestModel
            {
                ResourceType = resource.type,
                Quality = resource.quality,
                Amount = resource.amount * stacks
            });
        }
    }

    public void UpdateRequests(RecipeScriptableObject recipe, int stacks, int tier)
    {
        ResourceRequests.Clear();

        // Get the convertor for the specified tier
        RecipeConvertor convertor = recipe.GetConvertorForTier(tier);

        foreach (var resource in convertor.inputResources)
        {
            ResourceRequests.Add(new IndividualResourceRequestModel
            {
                ResourceType = resource.type,
                Quality = resource.quality,
                Amount = resource.amount * stacks
            });
        }
    }
}
