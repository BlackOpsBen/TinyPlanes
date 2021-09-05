using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    IDeathBehavior deathBehavior;
    IHitBehavior hitBehavior;

    [SerializeField] int startingHealth = 3;

    private int currentHealth;

    private bool isDead = false;

    private void Start()
    {
        deathBehavior = GetComponent<IDeathBehavior>();
        hitBehavior = GetComponent<IHitBehavior>();

        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        hitBehavior.TakeHit();

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    public float GetHealthPercentage()
    {
        return currentHealth / startingHealth;
    }

    private void Die()
    {
        isDead = true;
        deathBehavior.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(gameObject.tag))
        {
            Projectile projectile = collision.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.GetDamage());
                projectile.gameObject.SetActive(false);
            }
        }
    }
}
