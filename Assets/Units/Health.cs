using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    IDeathBehavior[] deathBehaviors;
    IHitBehavior[] hitBehaviors;

    [SerializeField] int startingHealth = 3;

    [SerializeField] MonoBehaviour[] DisableWhenDead;

    private int currentHealth;

    private bool isDead = false;

    private void Start()
    {
        deathBehaviors = GetComponents<IDeathBehavior>();
        hitBehaviors = GetComponents<IHitBehavior>();

        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        foreach (var hitBehavior in hitBehaviors)
        {
            hitBehavior.TakeHit();
        }

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }

        AudioManager.Instance.PlaySoundGroup(0); // TODO refactor sound playing
    }

    public float GetHealthPercentage()
    {
        return (float)currentHealth / startingHealth;
    }

    private void Die()
    {
        foreach (var behavior in DisableWhenDead)
        {
            behavior.enabled = false;
        }

        isDead = true;
        foreach (var deathBehavior in deathBehaviors)
        {
            deathBehavior.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(gameObject.tag))
        {
            Projectile projectile = collision.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.GetDamage());
                //projectile.ToggleActive(false);
                projectile.EndProjectile();
            }
        }
    }
}
