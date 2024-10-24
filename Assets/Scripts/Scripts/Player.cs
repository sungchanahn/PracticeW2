using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camera;
    Vector2 mousePos;

    public QuestDataSO questData;

    private void Awake()
    {
        QuestManager.Instance.Player = this;
    }

    private void Start()
    {
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }
}
