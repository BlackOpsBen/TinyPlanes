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
        try
        {
            unit.GetComponent<Spawnable>().Spawn(spawnPos, gameObject.tag);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Attempted to Spawn a unit that does not have the Spawnable component. " + ex);
        }
    }
}
