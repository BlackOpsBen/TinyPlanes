using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

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

            List<SpriteResolver> spriteResolvers = new List<SpriteResolver>();
            spriteResolvers.AddRange(newUnit.GetComponents<SpriteResolver>());
            spriteResolvers.AddRange(newUnit.GetComponentsInChildren<SpriteResolver>());

            foreach (SpriteResolver sr in spriteResolvers)
            {
                sr.SetCategoryAndLabel(sr.GetCategory(), newUnit.tag);
            }
        }
    }
}
