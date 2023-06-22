using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[InlineEditor]
public class RiteOfAssassination : RitualStrategy
{
    //name
    [ShowInInspector, ReadOnly]
    public string Name => "Rite of Assassination";
}
