using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СlashModel
{
    //two companies participating in battle
    private CompanyModel attacker;

    private CompanyModel defender;
    
    //fight between two companies
    public void Fight(out CompanyModel winner, out CompanyModel loser)
    {
        //later, abilities will trigger here
        //for now, just compare initial power of the companies

        //compare power of the companies
        if(attacker.Strength > defender.Strength)
        {
            //attacker wins
            winner = attacker;
            loser = defender;
        }
        else
        {
            //defender wins
            winner = defender;
            loser = attacker;
        }

        //determine the outcome of the fight
        CombatOutcome outcome = DetermineOutcome(winner, loser);

        //here casualties modifiers will be calculated for both winner and loser considering their respective resolve
    }

    //aftermath of the fight
    public void Aftermath(CompanyModel winner, CompanyModel loser)
    {
        List<UnitSlot> units = GetAllUnits(winner, loser);
        
        DetermineUnitOutcomes(units);
        
        CleanupBattlefield(units);
    }

    //determine the outcome of the fight
    //when calculating, consider that outcome is determined from the perspective of the attacker
    /* 
    private (float attackerCasualties, float defenderCasualties) CalculateCasualties(CompanyModel attacker, CompanyModel defender)
    {
        // Define sigmoid function to model the impact of resolve
        Func<float, float> sigmoid = x => (float)(1 / (1 + Math.Exp(-x)));
        
        // Normalize resolve values to the range [-10, 10] to fit into sigmoid function
        float attackerResolve = (attacker.Resolve. - 50) / 5; 
        float defenderResolve = (defender.Resolve - 50) / 5;

        // Apply sigmoid function to resolve values
        float attackerCasualtiesModifier = sigmoid(attackerResolve);
        float defenderCasualtiesModifier = sigmoid(defenderResolve);

        // Calculate casualties considering power level and resolve
        float attackerCasualties = defender.PowerLevel * defenderCasualtiesModifier;
        float defenderCasualties = attacker.PowerLevel * attackerCasualtiesModifier;

        return (attackerCasualties, defenderCasualties);
    } */

    private List<UnitSlot> GetAllUnits(CompanyModel winner, CompanyModel loser)
    {
        //collection of units
        List<UnitSlot> units = new List<UnitSlot>();

        //populate the collection
        units.AddRange(winner.roster);
        units.AddRange(loser.roster);

        return units;
    }

    private void DetermineUnitOutcomes(List<UnitSlot> units)
    {
        foreach(UnitSlot unitSlot in units)
        {
            //find the unit
            UnitModel unit = unitSlot.ContainedUnit;

            //make a dictionary and populate it with outcomes
            Dictionary<string, int> outcomes = new Dictionary<string, int>();
            outcomes.Add("survive", unit.SurvivalRate);
            outcomes.Add("decease", unit.DeceaseRate);

            //roll a dice
            string result = SaveThrow.Throw(outcomes);

            //switch the result
            switch(result)
            {
                case "survive":
                    //nothing happens
                    break;
                case "decease":
                    //mark the unit as dead
                    unit.IsDead = true;
                    break;
            }
        }
    }

    private void CleanupBattlefield(List<UnitSlot> units)
    {
        //remove dead units from the rosters (by clearing corresponding slots)
        foreach(UnitSlot unitSlot in units)
        {
            if(unitSlot.ContainedUnit != null && unitSlot.ContainedUnit.IsDead)
            {
                unitSlot.RemoveUnit();
            }
        }
    }

    public CombatOutcome DetermineOutcome(CompanyModel winner, CompanyModel loser)
    {
        // Edge case handling: when both strengths are 0, return a draw or a suitable default
        if (winner.Strength == 0 && loser.Strength == 0)
        {
            return CombatOutcome.PhyrricVictory; // or another suitable default
        }

        float relativeStrengthDifference = (float)(winner.Strength - loser.Strength) / Math.Max(winner.Strength, loser.Strength);

        CombatOutcome outcome = CombatOutcome.DevastatingDefeat;

        foreach (var range in OutcomeRanges)
        {
            if (relativeStrengthDifference < range.Key)
                break;
            
            outcome = range.Value;
        }

        return outcome;
    }

    private static readonly SortedDictionary<float, CombatOutcome> OutcomeRanges = new SortedDictionary<float, CombatOutcome>()
    {
        {-1f, CombatOutcome.DevastatingDefeat},
        {-0.8f, CombatOutcome.DecisiveDefeat},
        {-0.6f, CombatOutcome.SubstantialDefeat},
        {-0.4f, CombatOutcome.MarginalDefeat},
        {-0.2f, CombatOutcome.CloseDefeat},
        {0f, CombatOutcome.PhyrricVictory},
        {0.2f, CombatOutcome.MarginalVictory},
        {0.4f, CombatOutcome.SubstantialVictory},
        {0.6f, CombatOutcome.DecisiveVictory},
        {0.8f, CombatOutcome.HeroicVictory}
    };

}

public enum CombatRange
{
    Melee,
    Ranged
}

public enum CombatOutcome
{
    //from heroic victory to devastating defeat, 10 tiers, no draws
    //wins
    HeroicVictory,
    DecisiveVictory,
    SubstantialVictory,
    MarginalVictory,
    PhyrricVictory,

    //losses
    CloseDefeat,
    MarginalDefeat,
    SubstantialDefeat,
    DecisiveDefeat,
    DevastatingDefeat
}

//casualties
public enum CasualtyRate
{
    //losses, 6 tiers
    None,
    Light,
    Moderate,
    Heavy,
    Severe,
    Extermination
}