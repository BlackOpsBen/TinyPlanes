using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapOffsetFromTarget : MonoBehaviour
{
    private Transform target;

    private Vector2 offset;

    public void SetTarget(Transform targetTransform, Transform parent)
    {
        transform.parent = parent;
        target = targetTransform;
        offset = transform.position - target.position;
    }

    private void Update()
    {
        transform.position = (Vector2)target.position + offset;
    }
}
