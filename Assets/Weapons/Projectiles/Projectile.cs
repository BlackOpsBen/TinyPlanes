using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage = 1;

    [Tooltip("Speed in units per second")]
    [SerializeField] float speed = 10f;

    [Tooltip("Range in units")]
    [SerializeField] float range = 10f;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Collider2D mCollider;

    [SerializeField] private Rigidbody2D rb;

    private Vector2 firedFromPos;

    private void Update()
    {
        Vector2 directionToFiredFromPos = firedFromPos - (Vector2)transform.position;
        float dSqrToFiredFromPos = directionToFiredFromPos.sqrMagnitude;

        if (dSqrToFiredFromPos > range * range)
        {
            Debug.Log("Calling EndProjectile from self for being beyond range");
            EndProjectile();
            firedFromPos = transform.position;
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void EndProjectile()
    {
        Debug.Log("EndProjectile");
        spriteRenderer.enabled = false;
        mCollider.enabled = false;
        rb.velocity = Vector2.zero;
    }

    public void BeginProjectile(Vector2 startPosition)
    {
        Debug.Log("BeginProjectile");
        firedFromPos = startPosition;
        spriteRenderer.enabled = true;
        mCollider.enabled = true;
    }
}
