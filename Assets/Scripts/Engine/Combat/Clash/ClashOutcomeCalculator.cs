using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ClashOutcomeCalculator
{
    public enum CompanyClashOutcome
    {
        NotAScratch,
        SlightDamage,
        ModerateDamage,
        SevereDamage,
        CriticalDamage,
        DevastatingDamage,
        NearObliteration,
        Obliteration
    }
    private static readonly Dictionary<CompanyClashOutcome, float> thresholds = new Dictionary<CompanyClashOutcome, float>
    {
        { CompanyClashOutcome.NotAScratch, 1f / 3f },
        { CompanyClashOutcome.SlightDamage, 2f / 3f },
        { CompanyClashOutcome.ModerateDamage, 1f },
        { CompanyClashOutcome.SevereDamage, 1.5f },
        { CompanyClashOutcome.CriticalDamage, 2f },
        { CompanyClashOutcome.DevastatingDamage, 2.5f },
        { CompanyClashOutcome.NearObliteration, 3f },
    };

    public static CompanyClashOutcome Calculate(float powerRatio)
    {
        foreach (var outcome in Enum.GetValues(typeof(CompanyClashOutcome)).Cast<CompanyClashOutcome>().OrderBy(x => x))
        {
            if (powerRatio < thresholds[outcome])
            {
                return outcome;
            }
        }

        return CompanyClashOutcome.Obliteration;
    }
}
