using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float lerpSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPos, lerpSpeed * Time.deltaTime);
    }
}
