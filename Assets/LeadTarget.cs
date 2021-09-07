using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadTarget : MonoBehaviour
{
    private Targeting targeting;
    private float weaponSpeed;

    private GameObject target;
    private Rigidbody2D targetRigidBody;
    private Vector2 targetVelocity;
    private float leadDelay;

    private Vector2 leadPosition;

    private void Awake()
    {
        targeting = GetComponent<Targeting>();
        weaponSpeed = GetComponent<Arsenal>().GetCurrentWeapon().GetSpeed(); // TODO refactor to handle weapon switching
    }

    private void Update()
    {
        target = targeting.GetNearestTarget();

        if (target != null)
        {
            targetRigidBody = target.GetComponent<Rigidbody2D>();
            targetVelocity = targetRigidBody.velocity;

            leadDelay = Vector2.Distance(targetRigidBody.transform.position, transform.position) / weaponSpeed;

            leadPosition = (Vector2)targetRigidBody.transform.position + (targetVelocity * leadDelay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(leadPosition, .5f);
    }
}
