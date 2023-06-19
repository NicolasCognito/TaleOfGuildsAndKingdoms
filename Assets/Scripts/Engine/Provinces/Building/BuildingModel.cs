using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingModel : IEntity
{
    public virtual List<BuildingTag> DefaultTags { get; set; }

    public abstract bool ConstructionCondition();

    public abstract bool OperationalCondition();
}