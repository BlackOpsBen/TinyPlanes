using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDisableTarget : MonoBehaviour, IDeathBehavior
{
    private List<Target> targets = new List<Target>();

    private void Start()
    {
        Target baseTarget = GetComponent<Target>();
        if (baseTarget != null)
        {
            targets.Add(baseTarget);
        }

        try
        {
            Target[] wrapTargets = GetComponent<WrapTarget>().GetTargetWrapGroup().GetComponentsInChildren<Target>();
            targets.AddRange(wrapTargets);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("No wrapTargets found. " + ex);
        }
    }

    public void Die()
    {
        foreach (Target target in targets)
        {
            target.SetIsActive(false);
        }
    }

    public void Respawn()
    {
        foreach (Target target in targets)
        {
            target.SetIsActive(true);
        }
    }
}
