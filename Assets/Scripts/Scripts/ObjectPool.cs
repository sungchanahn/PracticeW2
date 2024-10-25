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
    public Dictionary<string, List<GameObject>> PoolDictionary;


    void Start()
    {
        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
        PoolDictionary = new Dictionary<string, List<GameObject>>();
        foreach (var pool in Pools)
        {
            List<GameObject> objectpool = new List<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                objectpool.Add(obj);
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

        List<GameObject> objectPool = PoolDictionary[_tag];
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return null;
    }

    public void Release(string tag, GameObject obj)
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        obj.SetActive(false);
    }
}