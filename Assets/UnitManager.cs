using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeadPoolManager))]
public class UnitManager : MonoBehaviour
{
    public static UnitManager instance { get; private set; }

    [SerializeField] private List<GameObject> units = new List<GameObject>();

    private DeadPoolManager deadPoolManager;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        deadPoolManager = GetComponent<DeadPoolManager>();

        deadPoolManager.InitDeadPools(units);
    }

    public List<GameObject> GetUnitList()
    {
        return units;
    }

    public GameObject GetUnitPrefab(int index)
    {
        return units[index];
    }
}
