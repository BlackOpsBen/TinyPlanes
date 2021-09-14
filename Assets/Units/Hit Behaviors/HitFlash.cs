using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour, IHitBehavior
{
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Sprite flashSprite;

    private Sprite defaultSprite;

    [SerializeField] float flashDuration = .1f;

    private float timer = 0f;

    private void Start()
    {
        defaultSprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > flashDuration)
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }

    public void TakeHit()
    {
        timer = 0f;
        spriteRenderer.sprite = flashSprite;
    }
}
