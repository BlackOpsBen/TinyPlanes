using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturable : MonoBehaviour
{
    [Header("Owning Faction")]
    [SerializeField] private int factionIndex;

    [Header("Capture Conditions")]
    [SerializeField] private List<Health> mustDestroyThese = new List<Health>();
    [SerializeField] private bool mustHaveSuperiority = true;
    [SerializeField] private float superiorityRequirement = 20f;
    [SerializeField] private float superiorityRadius = 15f;
    private float[] superiorityCounters;
    private bool allPrereqsDestroyed = false;

    private void Start()
    {
        superiorityCounters = new float[FactionManager.instance.GetNumFactions()];

        SetOwningFaction(factionIndex);
    }

    private void Update()
    {
        if (!allPrereqsDestroyed)
        {
            foreach (var health in mustDestroyThese)
            {
                if (health.GetCurrentHealth() != 0)
                {
                    return;
                }
            }
            allPrereqsDestroyed = true;
        }
        else
        {
            int[] qtyUnitsPerFaction = new int[superiorityCounters.Length];

            for (int i = 0; i < superiorityCounters.Length; i++)
            {
                GameObject[] factionTagged = GameObject.FindGameObjectsWithTag(FactionManager.instance.GetFaction(i).name);

                for (int j = 0; j < factionTagged.Length; j++)
                {
                    if (factionTagged[j].GetComponent<Health>() != null)
                    {
                        qtyUnitsPerFaction[i]++;
                    }
                }
            }
        }
    }

    public void SetOwningFaction(int factionIndex)
    {
        this.factionIndex = factionIndex;
        gameObject.tag = FactionManager.instance.GetFaction(factionIndex).name;
    }

    public int GetOwningFactionIndex()
    {
        return factionIndex;
    }
}
