using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Steering : MonoBehaviour
{
    [SerializeField] private float steerThresholdMagnitude = .9f;
    [SerializeField] private float defaultSteeringSpeed = 200f;

    private float steeringSpeedMultiplier = 1f;

    Vector2 desiredFacing;

    private void Awake()
    {
        desiredFacing = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, desiredFacing);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, defaultSteeringSpeed * steeringSpeedMultiplier * Time.deltaTime);
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (input.magnitude >= steerThresholdMagnitude)
        {
            desiredFacing = input;
        }
        else
        {
            desiredFacing = transform.up;
        }
    }

    public void SetSteeringSpeedMultiplier(float multiplier)
    {
        steeringSpeedMultiplier = multiplier;
    }
}
