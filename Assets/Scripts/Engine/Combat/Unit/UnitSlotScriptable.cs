using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;


//later should be rewritten to be inherit basic slot class
public class UnitSlotSriptable
{
    //allowed tags
    public List<string> AllowedTags { get; private set; } = new List<string>();

    [SerializeField]
    private bool disallowedTagsInitialized = false;


    //disallowed tags (show in inspector only if disallowed tags are initialized)
    [OdinSerialize, ShowIf("disallowedTagsInitialized")]
    public List<string> DisallowedTags { get; private set; } = new List<string>();

    [SerializeField]
    private bool necessaryTagsInitialized = false;

    //necessary tags (show in inspector only if necessary tags are initialized)
    [OdinSerialize, ShowIf("necessaryTagsInitialized")]
    public List<string> NecessaryTags { get; private set; } = new List<string>();
    
}
