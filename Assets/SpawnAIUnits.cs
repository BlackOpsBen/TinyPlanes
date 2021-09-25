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

            GameObject controlledUnit;

            if (ai != null)
            {
                controlledUnit = ai.GetComponent<PlayerController>().GetControlledUnit();
                controlledUnit.GetComponent<Health>().Respawn();
            }
            else
            {
                ai = Instantiate(aiControllerPrefab, transform);

                controlledUnit = Instantiate(UnitManager.instance.GetUnitPrefab(unitListIndex), transform);

                ai.GetComponent<PlayerController>().SetControlledUnit(controlledUnit);

                controlledUnit.AddComponent<Targeting>();
                controlledUnit.AddComponent<LeadTarget>();
                DeathDeadPool deathDeadPool = controlledUnit.AddComponent<DeathDeadPool>();
                deathDeadPool.Init(deadPool, ai);
            }

            ai.tag = gameObject.tag;

            controlledUnit.tag = gameObject.tag;

            DisplayCorrectSprites(controlledUnit);

            spawnPoint.Spawn(ai.GetComponent<PlayerController>().GetControlledUnit());

            timer = 0f;
        }
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
