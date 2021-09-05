using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage = 1;

    [SerializeField] float lifeSpan = 1f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > lifeSpan)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        timer = 0f;
    }

    public int GetDamage()
    {
        return damage;
    }
}
