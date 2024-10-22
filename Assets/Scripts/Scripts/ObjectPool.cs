using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int poolSize;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;


    void Start()
    {
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in Pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.tag, objectpool);
        }
    }

    public GameObject Get(string _tag)
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        if (!PoolDictionary.ContainsKey(_tag))
        {
            return null;
        }
        
        if (PoolDictionary[_tag].TryDequeue(out GameObject obj))
        {
            obj.SetActive(true);
            return obj;
        }
        else return null;
    }

    public void Release(string tag, GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
        PoolDictionary[tag].Enqueue(obj);
    }
}