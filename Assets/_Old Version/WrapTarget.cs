using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapTarget : MonoBehaviour
{
    [SerializeField] private GameObject targetWrapGroupPrefab;

    private GameObject targetWrapGroupInstance;

    private void Start()
    {

        Transform parent = GameObject.FindGameObjectWithTag("TargetWrapGroups").transform;
        targetWrapGroupInstance = Instantiate(targetWrapGroupPrefab, parent, true);
        targetWrapGroupInstance.GetComponent<ConstrainToParentTarget>().SetParent(transform);
    }

    public GameObject GetTargetWrapGroup()
    {
        return targetWrapGroupInstance;
    }
}
