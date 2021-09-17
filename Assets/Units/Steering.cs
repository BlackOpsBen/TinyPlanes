using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OnSteer(Vector2 rawLeftInput)
    {
        if (rawLeftInput.magnitude >= steerThresholdMagnitude)
        {
            desiredFacing = rawLeftInput;
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
