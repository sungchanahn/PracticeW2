using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;

    [SerializeField] private Dictionary<int, QuestDataSO> questDictionary;

    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
            }

            if (instance == null)
            {
                GameObject questManager = new GameObject("QuestManager");
                instance = questManager.AddComponent<QuestManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
}
