using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnAIUnit : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;

    private void Awake()
    {
        if (GetComponent<PlayerController>().GetControlledUnit() == null)
        {
            GameObject newUnit = Instantiate(unitPrefab, transform);
            newUnit.AddComponent<Targeting>();
            newUnit.AddComponent<LeadTarget>();
            newUnit.tag = "Red";
            GetComponent<PlayerController>().SetControlledUnit(newUnit);
        }
    }
}
