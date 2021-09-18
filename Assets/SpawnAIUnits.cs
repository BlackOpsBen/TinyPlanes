using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnPoint))]
public class SpawnAIUnits : MonoBehaviour
{
    [SerializeField] GameObject unitPrefab;

    [SerializeField] float interval = 10f;

    private SpawnPoint spawnPoint;

    private float timer = 0f;

    private void Start()
    {
        spawnPoint = GetComponent<SpawnPoint>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            spawnPoint.Spawn(unitPrefab);
            timer = 0f;
        }
    }
}
