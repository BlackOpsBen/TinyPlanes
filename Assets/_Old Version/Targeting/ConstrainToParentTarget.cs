using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainToParentTarget : MonoBehaviour
{
    private Transform parent;

    //private void Start()
    //{
    //    SetParent(parent);
    //}

    private void Update()
    {
        UpdatePosition();
    }

    public void SetParent(Transform parent)
    {
        this.parent = parent;
        GetComponent<InitTargetWrapOffsets>().Init(parent.GetComponent<Rigidbody2D>(), parent.tag);
    }

    private void UpdatePosition()
    {
        transform.position = parent.position;
    }
}
