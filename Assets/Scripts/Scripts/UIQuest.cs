using UnityEngine;

public class UIQuest : MonoBehaviour
{
    public GameObject questWindow;

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