using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage = 1;

    [SerializeField] float lifeSpan = 1f;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Collider2D mCollider;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > lifeSpan)
        {
            ToggleActive(false);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    public void ToggleActive(bool active)
    {
        spriteRenderer.enabled = active;
        mCollider.enabled = active;
        timer = 0f;
    }
}
