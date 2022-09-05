using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] float range = 10f;

    [SerializeField] private List<Target> potentialTargets = new List<Target>();
    [SerializeField] private Target target;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        target = GetNearestTarget();
    }

    private Target GetNearestTarget()
    {
        Target nearestTarget = null;

        float nearestTargetDistSqr = float.MaxValue;

        potentialTargets = new List<Target>(GameObject.FindObjectsOfType<Target>());

        foreach (var pt in potentialTargets)
        {
            if (pt.tag != gameObject.tag && pt.GetIsActive())
            {
                Vector2 directionToTarget = pt.transform.position - transform.position;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if (dSqrToTarget < nearestTargetDistSqr)
                {
                    nearestTarget = pt;
                    nearestTargetDistSqr = dSqrToTarget;
                }
            }
        }

        if (nearestTargetDistSqr < range * range)
        {
            return nearestTarget;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the nearest valid target if it is within range. Otherwise returns null.
    /// </summary>
    /// <returns></returns>
    public Target GetTarget()
    {
        return target;
    }

    public bool GetHasTarget()
    {
        return target != null;
    }
}
