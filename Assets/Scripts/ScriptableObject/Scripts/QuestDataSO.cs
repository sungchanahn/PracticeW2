using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    Monster,
    Encounter
}

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "ScriptableObject/QuestDataSO/QuestDataSO", order = 0)]
public class QuestDataSO : ScriptableObject
{
    public int QuestID;
    public QuestType QuestType;
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;
    public int[] QuestPrerequisites;
}