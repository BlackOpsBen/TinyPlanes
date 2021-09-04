using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private int perSecond = 2;
    [SerializeField] private float speed = 10f;

    public void Shoot(Transform muzzle)
    {
        GameObject spawn = Instantiate(projectile, muzzle.position, muzzle.rotation);
        Rigidbody2D rb = spawn.GetComponent<Rigidbody2D>();
        rb.velocity = muzzle.GetComponentInParent<Rigidbody2D>().velocity;
        rb.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
        Debug.Log("Firing " + name);
    }

    public int GetPerSecondRate()
    {
        return perSecond;
    }
}
