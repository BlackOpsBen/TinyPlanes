using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Boost))]
public class Drift : MonoBehaviour
{
    private Boost boost;

    private Acceleration acceleration;

    private Rigidbody2D rb;

    private float timeSinceEndedBoost = float.MaxValue;

    private bool isDrifting = false;

    private float driftTimer = 0f;

    [SerializeField] private float maxDriftTime = 2f;

    [SerializeField] private float driftThreshold = 0.5f;

    private float defaultDrag;

    [SerializeField] private float dragMultiplier = 0.25f;

    private void Awake()
    {
        boost = GetComponent<Boost>();
        acceleration = GetComponent<Acceleration>();
        rb = GetComponent<Rigidbody2D>();
        defaultDrag = rb.drag;
    }

    private void Update()
    {
        timeSinceEndedBoost = boost.GetCooldownTimer();

        if (isDrifting)
        {
            driftTimer += Time.deltaTime;
            if (driftTimer > maxDriftTime)
            {
                StopDrift();
            }
        }
    }

    public void OnDrift(bool performed, bool canceled) // TODO make it so you can do a boost right after a drift (or test and confirm it's not working)
    {
        if (performed && timeSinceEndedBoost < driftThreshold)
        {
            StartDrift();
        }
        else if (canceled)
        {
            StopDrift();
        }
    }

    private void StartDrift()
    {
        isDrifting = true;
        boost.StopBoost();
        acceleration.SetAccelerationMultiplier(0f);
        rb.drag = defaultDrag * dragMultiplier;
    }

    private void StopDrift()
    {
        isDrifting = false;
        acceleration.SetAccelerationMultiplier(1f);
        rb.drag = defaultDrag;
        driftTimer = 0f;
    }
}
