using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[Serializable]
public class RiteOfAssassination : RitualScriptable
{
    //internal classes for slots
    [Serializable]
    private class SlotTarget : SlotGenericSerialized<IEntity, RitualModel>
    {
        public override bool PrimaryCondition(IEntity target, params object[] objects)
        {
            //check if the target is a character
            if (target is CharacterModel)
            {
                //return true
                return true;
            }
            else
            {
                //return false
                return false;
            }
        }
    }

    [Serializable]
    private class SlotAssassin : SlotGenericSerialized<IEntity, RitualModel>
    {
        //perk needed for the assassin
        [SerializeField]
        private string requiredPerkType;

        //level of the perk needed for the assassin
        [SerializeField]
        private int requiredPerkLevel;


        public override bool PrimaryCondition(IEntity assassin, params object[] objects)
        {
            //check if the assassin is a character
            if (!(assassin is CharacterModel))
            {
                //return false
                return false;
            }

            //check if the assassin have rogue perk at level specified in the slot
            //get perk tree
            CharacterModel model = (CharacterModel)assassin;

            //get perk tree
            PerksTreeModel perkTree = model.PerksTree;

            //check if the perk tree contains the perk
            if (perkTree.HasPerk(requiredPerkType, requiredPerkLevel))
            {
                //return false
                return false;
            }

            //return true
            return true;
        }
    }

    //slots
    [OdinSerialize, InlineEditor]
    private SlotTarget slotTarget;

    [OdinSerialize, InlineEditor]
    private SlotAssassin slotAssassin;


    //verification of the ritual
    public override bool VerifyRitual(params object[] objects)
    {
        //get object[0] as a target slot model, and object[1] as an assassin slot model
        SlotModel<IEntity, RitualModel> Target = (SlotModel<IEntity, RitualModel>)objects[0];
        SlotModel<IEntity, RitualModel> Assassin = (SlotModel<IEntity, RitualModel>)objects[1];

        //check if the target and assassin are not the same character
        //if either of the slots is empty, return true as it's too early to verify the ritual
        if (Target == null || Assassin == null)
        {
            //return true
            return true;
        }

        //check if the target and assassin are not the same character
        if (Target.Containment == Assassin.Containment)
        {
            //return false
            return false;
        }

        //in case they are not the same character, it's okay
        return true;
    }
}
