using System.Collections.Generic;
using System.Linq;

public class HiringPoolModel
{
    //desired amount of heroes in hiring pool
    public int DesiredAmountOfHeroes { get; set; }

    //list of heroes in hiring pool
    public List<HiringPoolCharacterModel> Heroes { get; private set; }

    public HiringPoolModel()
    {
        Heroes = new List<HiringPoolCharacterModel>();
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

    private void ResetTurnsBeforeDecision(HiringPoolCharacterModel hero)
    {
        hero.TurnsBeforeDecision = 1;
    }

    private void HireHeroToHighestBidder(GuildModel faction, HiringPoolCharacterModel hero)
    {
        Heroes.Remove(hero);
    }

    //populate hiring pool with randomly generated heroes
    /*
    public void PopulateHiringPool(int numberOfHeroes)
    {
        for (int i = 0; i < numberOfHeroes; i++)
        {
            var hero = CharacterGenerator.GenerateCharacter();
            var bids = new Dictionary<GuildModel, int>();
            var biddingFactions = new List<GuildModel>();
            var minimalBid = 0;
            var turnsBeforeDecision = 3;

            var hiringPoolCharacter = new HiringPoolCharacterModel(hero, bids, biddingFactions, minimalBid, turnsBeforeDecision);

            Heroes.Add(hiringPoolCharacter);
        }
    }
    */
}
