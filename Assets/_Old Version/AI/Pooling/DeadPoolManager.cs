using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoolManager : MonoBehaviour
{
    [SerializeField] private List<DeadPool> deadPools = new List<DeadPool>();

    public void InitDeadPools(List<GameObject> units)
    {
        foreach (var unit in units)
        {
            DeadPool newDeadPool = gameObject.AddComponent<DeadPool>();
            newDeadPool.unitType = unit.name;
            deadPools.Add(newDeadPool);
        }
    }

    public DeadPool GetDeadPool(int index)
    {
        return deadPools[index];
    }

    public DeadPool GetDeadPool(string unitType)
    {
        foreach (var deadPool in deadPools)
        {
            if (deadPool.unitType == unitType)
            {
                return deadPool;
            }
        }

        return null;
    }
}
