using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [SerializeField] float range = 10f;

    [SerializeField] private GameObject[] potentialTargets;
    [SerializeField] private GameObject nearestTarget;

    [SerializeField] private bool isInRange = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        FindNearestTarget();
    }

    private void FindNearestTarget()
    {
        potentialTargets = GameObject.FindGameObjectsWithTag("Blue");

        nearestTarget = potentialTargets[0];

        float nearestTargetDistance = Vector2.Distance(transform.position, nearestTarget.transform.position);

        for (int i = 1; i < potentialTargets.Length; i++)
        {
            float distance = Vector2.Distance(transform.position, potentialTargets[i].transform.position);

            if (distance < nearestTargetDistance)
            {
                nearestTarget = potentialTargets[i];
                nearestTargetDistance = distance;
            }
        }

        isInRange = nearestTargetDistance < range;
    }

    public GameObject GetNearestTarget()
    {
        return nearestTarget;
    }
}
