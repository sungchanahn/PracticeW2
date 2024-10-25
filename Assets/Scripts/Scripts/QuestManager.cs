using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;

    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();

                if (instance == null)
                {
                    GameObject questManager = new GameObject("QuestManager");
                    instance = questManager.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    private Player _player;

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    public QuestSlot[] slots;
    public Transform questList;

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
            DontDestroyOnLoad(gameObject);
        }
        questList = GameObject.FindGameObjectWithTag("QuestList").transform;
    }

    private void Start()
    {
        slots = new QuestSlot[questList.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = questList.GetChild(i).GetComponent<QuestSlot>();
            slots[i].index = i;
        }
    }

    public void AddQuest()
    {
        QuestDataSO questData = Player.questData;

        QuestSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.questData = questData;
            UpdateUI();
        }
    }

    private QuestSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].questData == null)
            {
                return slots[i];
            }
        }
        return null;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].questData != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
}
