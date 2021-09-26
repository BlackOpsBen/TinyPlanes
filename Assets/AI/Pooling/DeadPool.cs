using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPool : MonoBehaviour
{
    [SerializeField] public string unitType;
    [SerializeField] private List<GameObject> dead = new List<GameObject>();

    public void MoveToDeadPool(GameObject unit)
    {
        dead.Add(unit);
    }

    public void RemoveFromDeadPool(GameObject unit)
    {
        dead.Remove(unit);
    }

    public GameObject GetNextInPool()
    {
        if (dead.Count > 0)
        {
            return dead[0];
        }
        else
        {
            return null;
        }
    }
}
