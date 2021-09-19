using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;

    public GameObject Spawn(GameObject unitPrefab)
    {
        GameObject spawnedUnit = Instantiate(unitPrefab, spawnPos.position, spawnPos.rotation, transform);

        spawnedUnit.tag = gameObject.tag;

        return spawnedUnit;
    }
}
