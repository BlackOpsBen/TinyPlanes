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

    private Targeting targeting;

    private LeadTarget leadTarget;

    private Vector2 destination;

    private bool isShooting = false;

    private float fireThreshold = 10f;

    private void Start()
    {
        AttemptGetControlledUnit();
    }

    private void AttemptGetControlledUnit()
    {
        controlledUnit = GetComponent<PlayerController>().GetControlledUnit();

        if (controlledUnit != null)
        {
            targeting = controlledUnit.GetComponent<Targeting>();
            leadTarget = controlledUnit.GetComponent<LeadTarget>();
        }
    }

    private void Update()
    {
        if (controlledUnit == null)
        {
            AttemptGetControlledUnit();
        }
        else
        {
            SetDestination();
            Steering();
            Shooting();
        }
    }

    private void SetDestination()
    {
        if (targeting.GetHasTarget())
        {
            if (leadTarget != null)
            {
                destination = leadTarget.GetTargetLead();
            }
            else
            {
                destination = targeting.GetTarget().transform.position;
            }
        }
        else if (GetDistanceSqrToDestination() < 25f)
        {
            destination = GetRandomDestination(); // TODO have AI get smart destination based on objectives
        }
    }

    private Vector2 GetRandomDestination()
    {
        float randX = UnityEngine.Random.Range(-(WorldWrapManager.instance.GetWorldDimensions().x / 2), WorldWrapManager.instance.GetWorldDimensions().x / 2);
        float randY = UnityEngine.Random.Range(-(WorldWrapManager.instance.GetWorldDimensions().y / 2), WorldWrapManager.instance.GetWorldDimensions().y / 2);
        return new Vector2(randX, randY);
    }

    private Vector2 GetDirectionToDestination()
    {
        return destination - (Vector2)controlledUnit.transform.position;
    }

    private float GetDistanceSqrToDestination()
    {
        return (destination - (Vector2)controlledUnit.transform.position).sqrMagnitude;
    }

    private void Steering()
    {
        Vector2 steerDirection = GetDirectionToDestination();
        Steer.Invoke(steerDirection);
    }

    private void Shooting()
    {
        if (targeting.GetHasTarget())
        {
            float angle = Vector2.Angle(GetDirectionToDestination().normalized, controlledUnit.transform.up);

            if (!isShooting && angle < fireThreshold)
            {
                StartShooting();
            }

            if (isShooting && angle > fireThreshold)
            {
                StopShooting();
            }
        }
        else
        {
            StopShooting();
        }
    }

    private void StartShooting()
    {
        ActionA.Invoke(true, false);
        isShooting = true;
    }

    private void StopShooting()
    {
        ActionA.Invoke(false, true);
        isShooting = false;
    }
}
