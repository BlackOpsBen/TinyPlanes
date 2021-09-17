using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform targetTransform;
    [SerializeField] private float leadDistance = 2f;

    private Rigidbody2D targetRigidBody;

    private void Update()
    {
        GameObject targetObject = GetComponentInParent<PlayerController>().GetControlledUnit();

        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
            targetRigidBody = targetTransform.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetTransform != null && targetRigidBody != null)
        {
            Vector3 targetPosFlat = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);

            Vector3 velocity3D = new Vector3(targetRigidBody.velocity.x, targetRigidBody.velocity.y, 0f);

            Vector3 leadPosition = targetPosFlat + velocity3D * leadDistance;

            transform.position = leadPosition;
        }
    }
}
