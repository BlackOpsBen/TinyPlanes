using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExplode : MonoBehaviour, IDeathBehavior
{
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    private Collider2D col;

    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem[] stopParticles;
    [SerializeField] ParticleSystem[] resumeParticles;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    public void Die()
    {
        foreach (var sr in spriteRenderers)
        {
            sr.enabled = false;
        }
        col.enabled = false;
        explosionParticles.Play();
        foreach (var ps in stopParticles)
        {
            ps.Stop();
        }

        AudioManager.Instance.PlaySoundGroup(2);
    }

    public void Respawn()
    {
        foreach (var sr in spriteRenderers)
        {
            sr.enabled = true;
        }

        col.enabled = true;

        foreach (var ps in resumeParticles)
        {
            ps.Play();
        }
    }
}
