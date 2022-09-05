using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Arsenal))]
[RequireComponent(typeof(LeadTarget))]
[RequireComponent(typeof(Targeting))]
public class AimTurret : MonoBehaviour
{
    [SerializeField] Transform turretPivot;

    [Tooltip("Used for determining which way the unit is facing as a default rotation for the turret when it has no target.")]
    [SerializeField] Transform turretBase;

    [SerializeField] float turretTurnSpeed = 100f;

    private LeadTarget leadTarget;

    private Targeting targeting;

    private Vector2 desiredFacing;

    private bool isOnTarget = false;
    private float onTargetThreshold = 1f;

    private void Awake()
    {
        leadTarget = GetComponent<LeadTarget>();
        targeting = GetComponent<Targeting>();
    }

    private void Update()
    {
        if (targeting.GetTarget() != null)
        {
            desiredFacing = leadTarget.GetTargetLead() - (Vector2)turretPivot.position;
        }
        else
        {
            Vector2 defaultTarget = turretBase.position + turretBase.up;
            desiredFacing = defaultTarget - (Vector2)turretPivot.position;
            Debug.DrawLine(turretPivot.position, defaultTarget, Color.cyan);
        }

        desiredFacing = desiredFacing.normalized;

        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, desiredFacing);
        turretPivot.rotation = Quaternion.RotateTowards(turretPivot.rotation, desiredRotation, turretTurnSpeed * Time.deltaTime);

        isOnTarget = Quaternion.Angle(desiredRotation, turretPivot.rotation) < onTargetThreshold;
    }

    /// <summary>
    /// Gets whether or not the turret is aiming at the target's lead position, give or take the threshold degrees.
    /// </summary>
    /// <returns></returns>
    public bool GetIsOnTarget()
    {
        return isOnTarget;
    }
}
