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
        SetTargetLead();
    }

    private void SetTargetLead()
    {
        target = targeting.GetNearestTarget();

        if (target != null)
        {
            targetRigidBody = target.GetComponent<Rigidbody2D>();

            if (targetRigidBody == null)
            {
                targetRigidBody = target.GetComponent<Target>().GetRigidBody();
            }

            targetVelocity = targetRigidBody.velocity;

            leadDelay = Vector2.Distance(target.transform.position, transform.position) / weaponSpeed;

            leadPosition = (Vector2)target.transform.position + (targetVelocity * leadDelay);
        }
    }

    public Vector2 GetTargetLead()
    {
        return leadPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(leadPosition, .5f);
    }
}