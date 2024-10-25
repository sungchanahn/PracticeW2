using UnityEngine;

public class UIQuest : MonoBehaviour
{
    public GameObject questWindow;

    private void Start()
    {
        questWindow.SetActive(false);
    }

    public void Toggle()
    {
        if (IsOpen())
        {
            questWindow.SetActive(false);
        }
        else
        {
            questWindow.SetActive(true);
        }
    }

    public bool IsOpen()
    {
        return questWindow.activeInHierarchy;
    }
}