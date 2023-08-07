using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//battle is a series of clashes that happens between many Companies
public class BattleModel
{
    //participating companies
    public List<CompanyModel> Companies { get; private set; }

    //sort companies by initiative
    public void SortCompaniesByInitiative()
    {
        //sort companies by initiative
        Companies.Sort((x, y) => y.Initiative.CompareTo(x.Initiative));
    }
}
