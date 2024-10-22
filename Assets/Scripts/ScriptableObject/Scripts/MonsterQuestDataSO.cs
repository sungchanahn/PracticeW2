using UnityEngine;

[CreateAssetMenu(fileName = "MonsterQuestDataSO", menuName = "ScriptableObject/QuestDataSO/MonsterQuestDataSO", order = 1)]
public class MonsterQuestDataSO : QuestDataSO
{
    public string MonsterName;
    public int TargetCount;
}