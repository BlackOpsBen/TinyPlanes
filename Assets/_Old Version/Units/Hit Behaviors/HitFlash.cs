using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class HitFlash : MonoBehaviour, IHitBehavior
{
    [SerializeField] private SpriteResolver[] spriteResolvers;

    [SerializeField] float flashDuration = .1f;

    private bool isFlashed = false;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (isFlashed && timer > flashDuration)
        {
            foreach (SpriteResolver sr in spriteResolvers)
            {
                sr.SetCategoryAndLabel(SpriteManager.SPRITE_CATEGORY_BASE, sr.GetLabel());
            }
            isFlashed = false;
        }
    }

    public void TakeHit()
    {
        timer = 0f;

        isFlashed = true;

        foreach (SpriteResolver sr in spriteResolvers)
        {
            sr.SetCategoryAndLabel(SpriteManager.SPRITE_CATEGORY_HIT, sr.GetLabel());
        }
    }
}
