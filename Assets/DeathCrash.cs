using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCrash : MonoBehaviour, IDeathBehavior
{
    [SerializeField] Acceleration acceleration;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 spinSpeedMinMax = new Vector2(45f, 45f);

    public void Die()
    {
        acceleration.SetIsAccelerating(false);

        float torque = UnityEngine.Random.Range(spinSpeedMinMax.x, spinSpeedMinMax.y);
        rb.AddTorque(torque);
    }
}
