using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private int perSecond = 2;
    //[SerializeField] private float speed = 10f;

    public int GetPerSecondRate()
    {
        return perSecond;
    }

    public GameObject GetProjectile()
    {
        return projectile;
    }

    //public float GetSpeed()
    //{
    //    return speed;
    //}
}
