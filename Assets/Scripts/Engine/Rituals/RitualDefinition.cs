using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class RitualDefinition
{
    public abstract bool VerifyRitual(params object[] objects);
}
