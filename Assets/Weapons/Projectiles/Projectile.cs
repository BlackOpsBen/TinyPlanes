using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage = 1;

    //[SerializeField] float lifeSpan = 1f;

    [Tooltip("Speed in units per second")]
    [SerializeField] float speed = 10f;

    [Tooltip("Range in units")]
    [SerializeField] float range = 10f;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Collider2D mCollider;

    private Vector2 firedFromPos;

    //private float timer = 0f;

    private void Update()
    {
        //timer += Time.deltaTime;

        //if (timer > lifeSpan)
        //{
        //    ToggleActive(false);
        //}

        Vector2 directionToFiredFromPos = firedFromPos - (Vector2)transform.position;
        float dSqrToFiredFromPos = directionToFiredFromPos.sqrMagnitude;

        if (dSqrToFiredFromPos > range * range)
        {
            EndProjectile();
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

    //public void ToggleActive(bool active)
    //{
    //    spriteRenderer.enabled = active;
    //    mCollider.enabled = active;
    //    //timer = 0f;
    //}

    public void EndProjectile()
    {
        spriteRenderer.enabled = false;
        mCollider.enabled = false;
    }

    public void BeginProjectile(Vector2 startPosition)
    {
        firedFromPos = startPosition;
        spriteRenderer.enabled = true;
        mCollider.enabled = true;
    }
}
