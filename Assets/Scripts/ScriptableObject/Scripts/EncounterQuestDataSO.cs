using UnityEngine;

[CreateAssetMenu(fileName = "EncounterQuestDataSO", menuName = "ScriptableObject/QuestDataSO/EncounterQuestDataSO", order = 2)]
public class EncounterQuestDataSO : QuestDataSO
{
    public string EncounterNPCName;
    public int EncounterNPCId;
}