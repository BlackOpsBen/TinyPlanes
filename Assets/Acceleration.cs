using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField] private float acceleration = 100f;
    [SerializeField] private float maxSpeed = 10f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.AddRelativeForce(Vector2.up * acceleration * Time.deltaTime, ForceMode2D.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}