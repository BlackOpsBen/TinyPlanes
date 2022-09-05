using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class RecolorToFaction : MonoBehaviour
{
    [SerializeField] private SpriteResolver[] spriteResolvers;

    private void Start()
    {
        SetSpriteColors();
    }

    public void SetSpriteColors()
    {
        foreach (var sr in spriteResolvers)
        {
            sr.SetCategoryAndLabel(sr.GetCategory(), gameObject.tag);
        }
    }
}
