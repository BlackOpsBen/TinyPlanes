using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boost : MonoBehaviour
{
    [SerializeField] private Steering steering;
    [SerializeField] private Acceleration acceleration;

    [SerializeField] private float maxBoostTime = 2f;

    [SerializeField] private float cooldownDelay = 4f;

    [Tooltip("Seconds of boost regained per second of cooldown (s/s)")]
    [SerializeField] private float cooldownSpeed = 0.5f;

    [SerializeField] private float steeringSpeedMultiplier = .25f;

    [SerializeField] private float boostSpeedMultiplier = 2f;
    [SerializeField] private float boostAccelerationMultiplier = 2f;

    private float boostTimer = 0f;

    private float cooldownTimer = 0f;

    private bool isBoosting = false;

    private bool canBoost = true;

    private void Update()
    {
        if (isBoosting)
        {
            boostTimer += Time.deltaTime;
        }
        else
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer > cooldownDelay)
            {
                boostTimer -= Time.deltaTime * cooldownSpeed;
                boostTimer = Mathf.Max(0f, boostTimer);
            }
        }

        if (boostTimer > maxBoostTime)
        {
            StopBoost();

            canBoost = false;
        }
        else
        {
            canBoost = true;
        }
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        if (context.performed && canBoost)
        {
            StartBoost();
        }
        else if (context.canceled)
        {
            StopBoost();
        }
    }

    private void StartBoost()
    {
        AudioManager.Instance.PlayUniqueSound("Boost");
        isBoosting = true;
        steering.SetSteeringSpeedMultiplier(steeringSpeedMultiplier);
        cooldownTimer = 0f;
        acceleration.SetMaxSpeedMultiplier(boostSpeedMultiplier);
        acceleration.SetAccelerationMultiplier(boostAccelerationMultiplier);
    }

    private void StopBoost()
    {
        isBoosting = false;
        steering.SetSteeringSpeedMultiplier(1f);
        acceleration.SetMaxSpeedMultiplier(1f);
        acceleration.SetAccelerationMultiplier(1f);
    }
}
