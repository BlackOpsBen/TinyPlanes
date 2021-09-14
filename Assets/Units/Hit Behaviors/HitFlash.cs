using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour, IHitBehavior
{
    [SerializeField] SpriteRenderer[] spriteRenderers;

    [SerializeField] Sprite[] flashSprites;

    private Sprite[] defaultSprites;

    [SerializeField] float flashDuration = .1f;

    private float timer = 0f;

    private void Start()
    {
        defaultSprites = new Sprite[spriteRenderers.Length];

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            defaultSprites[i] = spriteRenderers[i].sprite;
        }
        //defaultSprites = spriteRenderers.sprite;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > flashDuration)
        {
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].sprite = defaultSprites[i];
            }
            //spriteRenderers.sprite = defaultSprites;
        }
    }

    public void TakeHit()
    {
        timer = 0f;

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = flashSprites[i];
        }
        //spriteRenderers.sprite = flashSprites;
    }
}
