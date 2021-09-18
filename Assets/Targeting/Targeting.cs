using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] float range = 10f;

    [SerializeField] private List<GameObject> potentialTargets = new List<GameObject>();
    [SerializeField] private GameObject target;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        target = GetNearestTarget();
    }

    private GameObject GetNearestTarget()
    {
        GameObject nearestTarget = null;

        float nearestTargetDistSqr = float.MaxValue;

        potentialTargets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Blue")); // TODO get all enemy targets, not just all tagged with "blue"

        foreach (var pt in potentialTargets)
        {
            Vector2 directionToTarget = pt.transform.position - transform.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < nearestTargetDistSqr)
            {
                nearestTarget = pt;
                nearestTargetDistSqr = dSqrToTarget;
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
    public GameObject GetTarget()
    {
        return target;
    }
}
