using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Targeting))]
[RequireComponent(typeof(Arsenal))]
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
        //weaponSpeed = GetComponent<Arsenal>().GetCurrentWeapon().GetSpeed(); // TODO refactor to handle weapon switching
        weaponSpeed = GetComponent<Arsenal>().GetCurrentWeapon().GetProjectile().GetComponent<Projectile>().GetSpeed();
    }

    private void Update()
    {
        SetTargetLead();
    }

    private void SetTargetLead()
    {
        target = targeting.GetTarget();

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

    /// <summary>
    /// Returns the position that the projectile and the target will both reach at the same time assuming the target maintains it's current velocity.
    /// </summary>
    /// <returns></returns>
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
