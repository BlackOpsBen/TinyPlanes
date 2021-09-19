using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCrash : MonoBehaviour, IDeathBehavior
{
    [SerializeField] Acceleration acceleration; // TODO hide things that can be grabbed on Start
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Collider2D col;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 spinSpeedMinMax = new Vector2(45f, 180f);
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem[] stopParticles;
    [SerializeField] ParticleSystem[] resumeParticles;

    private bool isCrashing = false;

    private float timeToCrash = 2f;

    private float timer = 0f;

    private float torque;

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

    private void FixedUpdate()
    {
        if (isCrashing)
        {
            rb.AddTorque(torque, ForceMode2D.Force);
        }
    }

    private void Crash()
    {
        spriteRenderer.enabled = false;
        col.enabled = false;
        explosionParticles.Play();
        foreach (var ps in stopParticles)
        {
            ps.Stop();
        }

        AudioManager.Instance.PlaySoundGroup(2);
    }

    public void Die()
    {
        acceleration.SetIsAccelerating(false);

        torque = UnityEngine.Random.Range(-spinSpeedMinMax.y, spinSpeedMinMax.y);

        if (Mathf.Abs(torque) < spinSpeedMinMax.y)
        {
            torque += spinSpeedMinMax.x * Mathf.Sign(torque);
        }

        gameObject.layer = 6;

        isCrashing = true;

        AudioManager.Instance.PlayUniqueSound("Crash");
        AudioManager.Instance.PlayUniqueSound("Engine Failure");
    }

    public void Respawn()
    {
        acceleration.SetIsAccelerating(true);

        gameObject.layer = 0;

        isCrashing = false;

        spriteRenderer.enabled = true;

        col.enabled = true;

        foreach (var ps in resumeParticles)
        {
            ps.Play();
        }
    }
}
