using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour, ISpecialAbility
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

    private float cooldownTimer = 100f;

    private bool isBoosting = false;

    private bool canBoost = true;

    private Drift drift;

    private void Start()
    {
        drift = GetComponent<Drift>();
    }

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

    public void OnSpecial(bool performed, bool canceled)
    {
        if (performed && canBoost)
        {
            StartBoost();
        }
        else if (canceled)
        {
            StopBoost();
        }

        if (drift != null)
        {
            drift.OnDrift(performed, canceled);
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

    public void StopBoost()
    {
        isBoosting = false;
        steering.SetSteeringSpeedMultiplier(1f);
        acceleration.SetMaxSpeedMultiplier(1f);
        acceleration.SetAccelerationMultiplier(1f);
    }

    public float GetCooldownTimer()
    {
        return cooldownTimer;
    }
}
