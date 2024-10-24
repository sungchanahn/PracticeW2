using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestSlot : MonoBehaviour
{
    public QuestDataSO questData;
    public TextMeshProUGUI description;
    public int index;

    public void Set()
    {
        if (questData.QuestType == QuestType.Encounter)
        {
            EncounterQuestDataSO encounterQuestData = questData as EncounterQuestDataSO;
            description.text = $"Quest{encounterQuestData.QuestID.ToString()} - {encounterQuestData.QuestName}(Required Lvl: {encounterQuestData.QuestRequiredLevel}\n"
                + $"Talk with{encounterQuestData.EncounterNPCName}";
        }
        else if (questData.QuestType == QuestType.Monster)
        {
            MonsterQuestDataSO monsterQusetData = questData as MonsterQuestDataSO;
            description.text = $"Quest{monsterQusetData.QuestID.ToString()} - {monsterQusetData.QuestName}(Required Lvl: {monsterQusetData.QuestRequiredLevel}\n"
                + $"Hunting {monsterQusetData.MonsterName} ({monsterQusetData.TargetCount})";
        }
    }

    public void Clear()
    {
        description.text = string.Empty;
    }
}