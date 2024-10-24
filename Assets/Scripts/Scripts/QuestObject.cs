using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public QuestDataSO questData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            QuestManager.Instance.Player.questData = questData;
            QuestManager.Instance.AddQuest();
        }
    }
}