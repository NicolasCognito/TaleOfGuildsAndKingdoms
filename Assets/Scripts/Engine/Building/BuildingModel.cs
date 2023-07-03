using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingModel : IEntity
{
    public virtual List<string> DefaultTags { get; set; }

    public virtual List<AttachmentModel> Attachments { get; set; }

    public abstract bool ConstructionCondition();
}