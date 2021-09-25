using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance { get; private set; }

    [SerializeField] private List<GameObject> units = new List<GameObject>();

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
