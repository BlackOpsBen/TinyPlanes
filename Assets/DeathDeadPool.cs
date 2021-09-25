using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDeadPool : MonoBehaviour, IDeathBehavior
{
    private DeadPool deadPool;

    private GameObject controllingPlayer;

    public void Init(DeadPool deadPool, GameObject controllingPlayer)
    {
        this.deadPool = deadPool;
        this.controllingPlayer = controllingPlayer;
    }

    public void Die()
    {
        StartCoroutine(MoveToDeadPool());
    }

    public void Respawn()
    {
        deadPool.RemoveFromDeadPool(controllingPlayer);
    }

    private IEnumerator MoveToDeadPool()
    {
        yield return new WaitForSeconds(5f);
        deadPool.MoveToDeadPool(controllingPlayer);
    }
}
