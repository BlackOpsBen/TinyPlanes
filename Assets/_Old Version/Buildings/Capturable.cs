using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Capturable : MonoBehaviour
{
    [Header("Owning Faction")]
    [SerializeField] private int factionIndex;

    [Header("Capture Conditions")]
    [SerializeField] private List<Health> mustDestroyThese = new List<Health>();
    [SerializeField] private float superiorityRequirement = 20f;
    [SerializeField] private float superiorityRadius = 15f;
    private float[] superiorityCounters;
    private bool allPrereqsDestroyed = false;

    [Header("Optional Spawners")]
    [SerializeField] private List<SpawnAIUnits> aiSpawners = new List<SpawnAIUnits>();

    private RecolorToFaction recolor;

    private void Start()
    {
        recolor = GetComponent<RecolorToFaction>();

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
            foreach (var spawner in aiSpawners)
            {
                spawner.enabled = false;
            }
        }
        else
        {
            int[] qtyUnitsPerFaction = new int[superiorityCounters.Length];

            // Count all units with Superiority
            for (int i = 0; i < superiorityCounters.Length; i++)
            {
                Superiority[] superiorityUnits = GameObject.FindObjectsOfType<Superiority>();

                for (int j = 0; j < superiorityUnits.Length; j++)
                {
                    bool inRange = GetDistSqr(superiorityUnits[j].transform.position, transform.position) < superiorityRadius * superiorityRadius;
                    bool isAlive = superiorityUnits[j].GetIsActive();
                    if (inRange && isAlive)
                    {
                        int factionIndex = FactionManager.instance.GetFactionIndex(superiorityUnits[j].tag);
                        qtyUnitsPerFaction[factionIndex]++;
                    }
                }
            }

            // Add/Subtract Superiority Points for each unit
            for (int i = 0; i < qtyUnitsPerFaction.Length; i++)
            {
                for (int j = 0; j < qtyUnitsPerFaction.Length; j++)
                {
                    if (j == i)
                    {
                        superiorityCounters[j] += qtyUnitsPerFaction[i] * Time.deltaTime;
                    }
                    else
                    {
                        superiorityCounters[j] -= qtyUnitsPerFaction[i] * Time.deltaTime;
                    }

                    superiorityCounters[j] = Mathf.Max(superiorityCounters[j], 0f);
                }
            }

            // Check for takeover
            float maxValue = superiorityCounters.Max();

            if (maxValue > superiorityRequirement)
            {
                SetOwningFaction(superiorityCounters.ToList().IndexOf(maxValue));
                Reset();
            }
        }
    }

    private float GetDistSqr(Vector2 a, Vector2 b)
    {
        Vector2 direction = a - b;
        return direction.sqrMagnitude;
    }

    public void SetOwningFaction(int factionIndex)
    {
        this.factionIndex = factionIndex;
        gameObject.tag = FactionManager.instance.GetFaction(factionIndex).name;
        foreach (var building in mustDestroyThese)
        {
            building.tag = gameObject.tag;
        }
        Debug.LogWarning("New Faction Owner: " + FactionManager.instance.GetFaction(factionIndex).name + factionIndex.ToString());

        foreach (var spawner in aiSpawners)
        {
            spawner.enabled = true;
        }

        if (recolor != null)
        {
            recolor.SetSpriteColors();
        }
    }

    public int GetOwningFactionIndex()
    {
        return factionIndex;
    }

    public void Reset()
    {
        for (int i = 0; i < superiorityCounters.Length; i++)
        {
            superiorityCounters[i] = 0f;
        }

        allPrereqsDestroyed = false;

        foreach (var health in mustDestroyThese)
        {
            health.Respawn();
        }
    }

    public float GetCounter(int index)
    {
        return superiorityCounters[index];
    }
}
