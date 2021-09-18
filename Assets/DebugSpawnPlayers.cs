using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugSpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;

    private PlayerInput[] playerInputs;

    public void SpawnPlayerUnit(int playerIndex)
    {
        playerInputs = FindObjectsOfType<PlayerInput>();

        Debug.Log("Found " + playerInputs.Length + " PlayerInputs.");

        if (playerInputs.Length < playerIndex + 1)
        {
            Debug.LogWarning("Player " + (playerIndex + 1).ToString() + " has not joined yet.");
        }
        else if (playerInputs[playerIndex].GetComponent<PlayerController>().GetControlledUnit() == null)
        {
            GameObject newUnit = Instantiate(unitPrefab);
            if (playerIndex == 0)
            {
                newUnit.tag = "Blue";
            }
            else
            {
                newUnit.tag = "Red";
            }
            playerInputs[playerIndex].GetComponent<PlayerController>().SetControlledUnit(newUnit);
        }
    }
}
