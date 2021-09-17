using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;

    private PlayerController[] playerControllers;

    public void SpawnPlayerUnit(int playerIndex)
    {
        playerControllers = FindObjectsOfType<PlayerController>();

        Debug.Log("Found " + playerControllers.Length + " player controllers.");

        if (playerControllers.Length < playerIndex + 1)
        {
            Debug.LogWarning("Player " + (playerIndex + 1).ToString() + " has not joined yet.");
        }
        else if (playerControllers[playerIndex].GetControlledUnit() == null)
        {
            GameObject newUnit = Instantiate(unitPrefab);
            playerControllers[playerIndex].SetControlledUnit(newUnit);
        }
    }
}
