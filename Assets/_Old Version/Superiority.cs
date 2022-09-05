using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Superiority : MonoBehaviour, IDeathBehavior
{
    private bool isActive = true;

    public void Die()
    {
        isActive = false;
    }

    public void Respawn()
    {
        isActive = true;
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}
