using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pools : MonoBehaviour
{
    [SerializeField] private int maxPerPool = 50;

    private List<Pool> pools = new List<Pool>();

    public void Init(List<Weapon> weapons)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            pools.Add(new Pool(maxPerPool, weapons[i]));
        }
    }

    public GameObject GetNextInPool(int weaponIndex)
    {
        Pool pool = pools[weaponIndex];

        if (pool.instances.Count <= pool.currentIndex)
        {
            GameObject newInstance = Instantiate(pool.prefab);
            newInstance.tag = gameObject.tag;
            pool.instances.Add(newInstance);
        }

        GameObject toReturn = pool.instances[pool.currentIndex];

        pool.currentIndex++;
        pool.currentIndex %= pool.maxInstances;

        return toReturn;
    }
}

public class Pool
{
    public int maxInstances = 50;

    public GameObject prefab;

    public List<GameObject> instances = new List<GameObject>();

    public int currentIndex = 0;

    public Pool(int maxInstances, Weapon weapon)
    {
        this.maxInstances = maxInstances;

        prefab = weapon.GetProjectile();
    }
}
