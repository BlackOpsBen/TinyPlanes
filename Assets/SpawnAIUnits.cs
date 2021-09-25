using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

[RequireComponent(typeof(SpawnPoint))]
public class SpawnAIUnits : MonoBehaviour
{
    [SerializeField] GameObject aiControllerPrefab;

    [SerializeField] float interval = 10f;

    private DeadPool deadPool;

    public int unitListIndex = 0;

    private SpawnPoint spawnPoint;

    private float timer = 0f;

    private void Start()
    {
        spawnPoint = GetComponent<SpawnPoint>();

        deadPool = UnitManager.instance.GetComponent<DeadPoolManager>().GetDeadPool(unitListIndex);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            GameObject ai = deadPool.GetNextInPool();

            if (ai == null)
            {
                ai = Instantiate(aiControllerPrefab, transform);
                InitializeNewAIUnit(ai);
            }
            else
            {
                ai.GetComponent<PlayerController>().GetControlledUnit().GetComponent<Health>().Respawn();
            }

            spawnPoint.Spawn(ai.GetComponent<PlayerController>().GetControlledUnit());

            timer = 0f;
        }
    }

    private void InitializeNewAIUnit(GameObject ai)
    {
        ai.tag = gameObject.tag;

        GameObject newUnit = Instantiate(UnitManager.instance.GetUnitPrefab(unitListIndex), transform);

        newUnit.tag = gameObject.tag;
        newUnit.AddComponent<Targeting>();
        newUnit.AddComponent<LeadTarget>();
        DeathDeadPool deathDeadPool = newUnit.AddComponent<DeathDeadPool>();
        deathDeadPool.Init(deadPool, ai);

        ai.GetComponent<PlayerController>().SetControlledUnit(newUnit);

        DisplayCorrectSprites(newUnit);
    }

    private static void DisplayCorrectSprites(GameObject newUnit)
    {
        List<SpriteResolver> spriteResolvers = new List<SpriteResolver>();
        spriteResolvers.AddRange(newUnit.GetComponents<SpriteResolver>());
        spriteResolvers.AddRange(newUnit.GetComponentsInChildren<SpriteResolver>());

        foreach (SpriteResolver sr in spriteResolvers)
        {
            sr.SetCategoryAndLabel(sr.GetCategory(), newUnit.tag);
        }
    }
}
