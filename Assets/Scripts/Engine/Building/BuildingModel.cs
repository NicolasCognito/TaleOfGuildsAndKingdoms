using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingModel : IEntity
{
    public virtual List<string> DefaultTags { get; set; }

    public virtual List<AttachmentModel> Attachments { get; set; }

    public abstract bool ConstructionCondition();

    //check if have attachement with given name
    public bool HasAttachment(string attachmentName)
    {
        foreach (var attachment in Attachments)
        {
            if (attachment.Name == attachmentName) 
            {
                return true;
            }
        }
        return false;
    }

    //check if have all attachments with names in the list
    public bool HasAllAttachments(List<string> attachmentNames)
    {
        foreach(var name in attachmentNames)
        {
            if(!HasAttachment(name))
            {
                return false;
            }    
        }
        return true;
    }

    //check if have any attachments with names in the list
    public bool HasAnyAttachments(List<string> attachmentNames)
    {
        foreach(var name in attachmentNames)
        {
            if(HasAttachment(name))
            {
                return true; 
            }
        }
        return false;
    }
}