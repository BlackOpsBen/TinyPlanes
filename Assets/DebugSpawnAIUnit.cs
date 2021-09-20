using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnAIUnit : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;

    private void Start()
    {
        if (GetComponent<PlayerController>().GetControlledUnit() == null)
        {
            GameObject newUnit = Instantiate(unitPrefab, transform);
            newUnit.tag = gameObject.tag;

            newUnit.AddComponent<Targeting>();
            newUnit.AddComponent<LeadTarget>();
            
            GetComponent<PlayerController>().SetControlledUnit(newUnit);
        }
    }
}
