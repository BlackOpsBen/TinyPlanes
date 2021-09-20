using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pools : MonoBehaviour
{
    [SerializeField] private int maxPerPool = 50;

    private List<Pool> pools = new List<Pool>();

    public void Init(int numPools, List<GameObject> prefabs)
    {
        for (int i = 0; i < numPools; i++)
        {
            pools.Add(new Pool(maxPerPool, prefabs[i]));
        }
    }

    public GameObject GetNextInPool(int weaponIndex)
    {
        Pool pool = pools[weaponIndex];

        if (pool.GetCount() <= pool.GetCurrentIndex())
        {
            GameObject newInstance = Instantiate(pool.GetPrefab());
            newInstance.tag = gameObject.tag;
            pool.AddInstance(newInstance);
        }

        GameObject toReturn = pool.GetCurrentInstance();

        return toReturn;
    }
}

public class Pool
{
    private int maxInstances = 50;

    private GameObject prefab;

    private List<GameObject> instances = new List<GameObject>();

    private int currentIndex = 0;

    public Pool(int maxInstances, GameObject prefab)
    {
        this.maxInstances = maxInstances;
        this.prefab = prefab;
    }

    public int GetCount()
    {
        return instances.Count;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }

    public void AddInstance(GameObject instance)
    {
        instances.Add(instance);
    }

    public GameObject GetCurrentInstance()
    {
        GameObject toReturn = instances[currentIndex];
        CycleIndex();
        return toReturn;
    }

    private void CycleIndex()
    {
        currentIndex++;
        currentIndex %= maxInstances;
    }
}
