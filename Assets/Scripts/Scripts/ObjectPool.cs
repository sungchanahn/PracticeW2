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
        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
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
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
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
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        obj.SetActive(false);
        PoolDictionary[tag].Enqueue(obj);
    }
}