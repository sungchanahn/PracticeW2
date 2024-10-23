using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }


    public ObjectPool pool;
    public Transform monster;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        pool = GetComponent<ObjectPool>();
    }
}