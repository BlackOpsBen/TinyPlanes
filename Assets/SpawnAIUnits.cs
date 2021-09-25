using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnPoint))]
public class SpawnAIUnits : MonoBehaviour
{
    [SerializeField] GameObject aiControllerPrefab;

    [SerializeField] float interval = 10f;

    public int unitListIndex = 0;

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
            spawnPoint.Spawn(aiControllerPrefab);
            timer = 0f;
        }
    }
}
