using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float leadDistance = 2f;

    private Rigidbody2D targetRigidBody;

    private void Awake()
    {
        targetRigidBody = targetTransform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosFlat = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);

        //Vector3 leadPosition = targetPosFlat + targetTransform.up * leadDistance;

        Vector3 velocity3D = new Vector3(targetRigidBody.velocity.x, targetRigidBody.velocity.y, 0f);

        Vector3 leadPosition = targetPosFlat + velocity3D * leadDistance;

        //transform.position = Vector3.Lerp(transform.position, leadPosition, lerpSpeed * Time.deltaTime);

        transform.position = leadPosition;
    }
}
