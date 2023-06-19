using System.Collections.Generic;
using System.Linq;

public class HiringPool
{
    public List<HiringPoolUnit> Heroes { get; private set; }

    public HiringPool()
    {
        Heroes = new List<HiringPoolUnit>();
    }

    public void EndTurn()
    {
        DecrementTurnsBeforeDecision();
        ProcessHiring();
    }

    private void DecrementTurnsBeforeDecision()
    {
        foreach (var hero in Heroes)
        {
            hero.TurnsBeforeDecision--;
        }
    }

    private void ProcessHiring()
    {
        var heroesToHire = Heroes
            .Where(hero => hero.TurnsBeforeDecision <= 0)
            .ToList();

        foreach (var hero in heroesToHire)
        {
            var highestBid = hero.Bids.Values.Max();

            var factionsWithHighestBid = hero.Bids
                .Where(bid => bid.Value == highestBid)
                .Select(bid => bid.Key)
                .ToList();

            if (HasMultipleHighestBidders(factionsWithHighestBid))
            {
                ResetTurnsBeforeDecision(hero);
                continue;
            }

            HireHeroToHighestBidder(factionsWithHighestBid.First(), hero);
        }
    }

    private bool HasMultipleHighestBidders(List<GuildModel> factionsWithHighestBid)
    {
        return factionsWithHighestBid.Count > 1;
    }

    private void ResetTurnsBeforeDecision(HiringPoolUnit hero)
    {
        hero.TurnsBeforeDecision = 1;
    }

    private void HireHeroToHighestBidder(GuildModel faction, HiringPoolUnit hero)
    {
        faction.Hire(hero.Hero);
        Heroes.Remove(hero);
    }
}
