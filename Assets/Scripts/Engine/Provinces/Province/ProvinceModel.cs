using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceModel : IEntity
{
    //reference to the province's neighbours list
    private List<ProvinceModel> _neighbours;

    //reference to the inventory of the province
    private InventoryModel _inventory;

    //building sites are the places where the player can build new buildings
    private List<SiteModel> _buildingSites;

    //demand are the resources that the province needs each turn to maintain its prosperity tier
    private ProvinceDemandModel _demand;

    //stats block
    private int _population;

    public ProvinceStatModel Magic;

    public ProvinceStatModel Military;

    public ProvinceStatModel Prosperity;

    //loyalty is represented by dictionary of factions and their reputation among the locals
    private Dictionary<FactionModel, int> _loyalty;


}
