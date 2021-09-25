using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoolManager : MonoBehaviour
{
    [SerializeField] private List<DeadPool> deadPools = new List<DeadPool>();

    private void Start()
    {
        foreach (var unit in UnitManager.instance.GetUnitList())
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
}
