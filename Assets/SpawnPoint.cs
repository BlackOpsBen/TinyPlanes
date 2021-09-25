using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    /// <summary>
    /// Takes an existing object reference and (re)spawns it.
    /// </summary>
    /// <param name="unit"></param>
    public void Spawn(GameObject unit)
    {
        unit.transform.position = spawnPos.position;
        unit.transform.rotation = spawnPos.rotation;
        Rigidbody2D rb = unit.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.position = spawnPos.position;
        rb.SetRotation(spawnPos.rotation);
    }
}
