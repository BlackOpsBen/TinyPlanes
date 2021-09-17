using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject targetUnitObject;

    [SerializeField] private float leadDistance = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform targetTransform;

        Rigidbody2D targetRigidBody;

        if (targetUnitObject != null)
        {
            targetTransform = targetUnitObject.transform;

            targetRigidBody = targetUnitObject.GetComponent<Rigidbody2D>();

            Vector3 targetPosFlat = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);

            Vector3 velocity3D = new Vector3(targetRigidBody.velocity.x, targetRigidBody.velocity.y, 0f);

            Vector3 leadPosition = targetPosFlat + velocity3D * leadDistance;

            transform.position = leadPosition;
        }
    }
}
