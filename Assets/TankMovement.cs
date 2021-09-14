using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private float defaultSteeringSpeed = 200f;

    [SerializeField] private Transform target;

    [SerializeField] private float forwardAngleMax = 15f;

    [SerializeField] private float maxSpeed = 20f;

    [SerializeField] private float acceleration = 50f;

    [Tooltip("Used for rotating body towards heading")]
    [SerializeField] private Transform tankBody;

    [SerializeField] private float stopDistance = 1f;

    private Rigidbody2D rb;

    Vector2 desiredFacing;

    private void Awake()
    {
        desiredFacing = Vector2.up;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        desiredFacing = (target.position - transform.position).normalized;

        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, desiredFacing);
        tankBody.rotation = Quaternion.RotateTowards(tankBody.rotation, desiredRotation, defaultSteeringSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (Vector2.Angle(desiredFacing, tankBody.up) < forwardAngleMax && Vector2.Distance(target.position, transform.position) > stopDistance)
        {
            rb.AddRelativeForce(tankBody.up * acceleration * Time.deltaTime, ForceMode2D.Force);
            Vector2 clampedVelocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
            rb.velocity = Vector2.Lerp(rb.velocity, clampedVelocity, Time.deltaTime);
        }
    }
}
