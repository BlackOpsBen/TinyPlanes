using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCrash : MonoBehaviour, IDeathBehavior
{
    [SerializeField] Acceleration acceleration; // TODO hide things that can be grabbed on Start
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Collider2D collider;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 spinSpeedMinMax = new Vector2(45f, 45f);
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem[] stopParticles;

    private bool isCrashing = false;

    private float timeToCrash = 2f;

    private float timer = 0f;

    private void Update()
    {
        if (isCrashing)
        {
            timer += Time.deltaTime;
        }

        if (timer > timeToCrash)
        {
            Crash();
            isCrashing = false;
            timer = 0f;
        }
    }

    private void Crash()
    {
        spriteRenderer.enabled = false;
        collider.enabled = false;
        explosionParticles.Play();
        foreach (var ps in stopParticles)
        {
            ps.Stop();
        }
    }

    public void Die()
    {
        acceleration.SetIsAccelerating(false);

        float torque = UnityEngine.Random.Range(spinSpeedMinMax.x, spinSpeedMinMax.y);
        rb.AddTorque(torque);

        gameObject.layer = 6;

        isCrashing = true;
    }
}
