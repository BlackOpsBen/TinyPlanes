using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool : MonoBehaviour
{
    [SerializeField] private int maxInstances = 50;

    private List<GameObject> instances = new List<GameObject>();

    private int currentIndex = 0;

    //public GameObject GetNextInstance(GameObject prefab)
    //{
    //    if (instances.Count <= currentIndex)
    //    {
    //        instances.Add()
    //    }
    //}
}
