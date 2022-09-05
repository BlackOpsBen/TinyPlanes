using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField] private float acceleration = 100f;

    [SerializeField] private float accelerationMultiplier = 1f;

    [SerializeField] private float maxSpeed = 10f;

    [SerializeField] private float maxSpeedMultiplier = 1f;

    private bool isAccelerating = true;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isAccelerating)
        {
            Move();
        }
    }

    private void Move()
    {
        rb.AddRelativeForce(Vector2.up * acceleration * accelerationMultiplier * Time.deltaTime, ForceMode2D.Force);

        Vector2 clampedVelocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed * maxSpeedMultiplier);
        rb.velocity = Vector2.Lerp(rb.velocity, clampedVelocity, Time.deltaTime);
    }

    public void SetIsAccelerating(bool value)
    {
        isAccelerating = value;
    }

    public void SetMaxSpeedMultiplier(float multiplier)
    {
        maxSpeedMultiplier = multiplier;
    }

    public void SetAccelerationMultiplier(float multiplier)
    {
        accelerationMultiplier = multiplier;
    }
}
