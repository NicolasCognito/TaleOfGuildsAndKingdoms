using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestModel : IEntity
{
    //quest is a special task that is given to the Guilds by the Kingdom

    //reward for completing the quest
    private QuestRewardModel reward;


    //list of guilds that can accept the quest
    public List<GuildModel> guilds = new List<GuildModel>();

    //list of guilds that have accepted the quest
    public List<GuildModel> acceptedGuilds = new List<GuildModel>();

    //form reward for completing the quest
    public abstract QuestRewardModel GenerateReward();

    //reward method for completing the quest
    public abstract void GetReward();

    //condition for completing the quest
    public abstract bool QuestCondition();

    //accepting the quest by the Guild (not abstract because it is the same for all quests)

}
