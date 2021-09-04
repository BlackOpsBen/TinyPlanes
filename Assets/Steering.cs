using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Steering : MonoBehaviour
{
    [SerializeField] private float steerThresholdMagnitude = .9f;
    [SerializeField] private float steeringSpeed = 20f;

    Vector2 desiredFacing;

    private void Awake()
    {
        desiredFacing = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, desiredFacing);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, steeringSpeed * Time.deltaTime);
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
}
