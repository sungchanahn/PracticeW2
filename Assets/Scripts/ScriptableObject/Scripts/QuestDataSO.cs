using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "ScriptableObject/QuestDataSO/QuestDataSO", order = 0)]
public class QuestDataSO : ScriptableObject
{
    public int QuestID;
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;
    public int[] QuestPrerequisites;
}