using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Arsenal))]
[RequireComponent(typeof(LeadTarget))]
public class AimTurret : MonoBehaviour
{
    [SerializeField] Transform turretPivot;

    [SerializeField] float turretTurnSpeed = 100f;

    private Arsenal arsenal;

    private LeadTarget leadTarget;

    private Vector2 desiredFacing;

    private bool isOnTarget = false;
    private float onTargetThreshold = 1f;

    private void Awake()
    {
        arsenal = GetComponent<Arsenal>();
        leadTarget = GetComponent<LeadTarget>();
    }

    private void Update()
    {
        desiredFacing = leadTarget.GetTargetLead() - (Vector2)turretPivot.position;
        desiredFacing = desiredFacing.normalized;

        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, desiredFacing);
        turretPivot.rotation = Quaternion.RotateTowards(turretPivot.rotation, desiredRotation, turretTurnSpeed * Time.deltaTime);

        isOnTarget = Quaternion.Angle(desiredRotation, turretPivot.rotation) < onTargetThreshold;

        arsenal.SetIsShooting(isOnTarget);
    }
}
