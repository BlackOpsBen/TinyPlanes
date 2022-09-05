using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
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

            newUnit.tag = FactionManager.instance.GetFaction(playerIndex).name;

            List<SpriteResolver> spriteResolvers = new List<SpriteResolver>();

            spriteResolvers.AddRange(newUnit.GetComponents<SpriteResolver>());
            spriteResolvers.AddRange(newUnit.GetComponentsInChildren<SpriteResolver>());

            foreach (SpriteResolver sr in spriteResolvers)
            {
                sr.SetCategoryAndLabel(sr.GetCategory(), newUnit.tag);
            }

            playerInputs[playerIndex].GetComponent<PlayerController>().SetControlledUnit(newUnit);
        }
    }
}
