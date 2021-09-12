using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFire : MonoBehaviour, IHitBehavior
{
    [SerializeField] ParticleSystem[] particleSystems;
    [SerializeField] Health health;
    [SerializeField] float fireStartThreshold = .5f;
    private bool isOnFire = false;

    public void TakeHit()
    {
        if (!isOnFire && health.GetHealthPercentage() < fireStartThreshold)
        {
            isOnFire = true;
            foreach (ParticleSystem ps in particleSystems)
            {
                ps.Play();
            }
        }
    }
}
