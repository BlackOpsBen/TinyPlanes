using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class AIInput : MonoBehaviour
{
    [Header("Action Event Listeners")]
    [SerializeField] public UnityEvent<Vector2> Steer;

    [SerializeField] public UnityEvent<bool, bool> ActionA;

    [SerializeField] public UnityEvent<bool, bool> ActionB;

    private GameObject controlledUnit;

    private LeadTarget leadTarget;

    private bool isShooting = false;

    private float fireThreshold = 10f;

    private void Start()
    {
        controlledUnit = GetComponent<PlayerController>().GetControlledUnit();

        if (controlledUnit != null)
        {
            leadTarget = controlledUnit.GetComponent<LeadTarget>();
        }
    }

    private void Update()
    {
        Steering();
        Shooting();
    }

    private void Steering()
    {
        Vector2 steerDirection = GetDirectionToNearestTarget();
        Steer.Invoke(steerDirection);
    }

    private Vector2 GetDirectionToNearestTarget()
    {
        if (leadTarget != null)
        {
            return leadTarget.GetTargetLead() - (Vector2)controlledUnit.transform.position;
        }
        else
        {
            if (controlledUnit == null)
            {
                Debug.LogWarning("AI does not have a controlled unit yet.");
                // Nothing to move
                return Vector2.zero;
            }
            else
            {
                // Nowhere to go
                Debug.LogWarning("AI controlled unit does not have a LeadTarget component.");
                return Vector2.zero;
            }
        }
    }

    private void Shooting()
    {
        float angle = Vector2.Angle(GetDirectionToNearestTarget().normalized, controlledUnit.transform.up);

        if (!isShooting && angle < fireThreshold)
        {
            ActionA.Invoke(true, false);
            isShooting = true;
        }

        if (isShooting && angle > fireThreshold)
        {
            ActionA.Invoke(false, true);
            isShooting = false;
        }
    }
}
