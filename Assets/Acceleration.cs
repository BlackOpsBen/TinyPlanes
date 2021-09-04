using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField] float minSpeed = 1f;
    [SerializeField] float maxSpeed = 5f;

    private float currentSpeed = 1f;
    private float acceleration = 2f;

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void SetThrottle(float value)
    {
        float direction = Mathf.Sign(value);
        currentSpeed += acceleration * direction * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
    }
}
