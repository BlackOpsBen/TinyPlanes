using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> units = new List<GameObject>();

    public List<GameObject> GetUnitList()
    {
        return units;
    }
}
