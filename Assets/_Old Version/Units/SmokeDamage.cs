using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] Health health;

    [SerializeField] Color fineColor;

    [SerializeField] Color damageColor1;
    [SerializeField] Color damageColor2;

    [SerializeField] float damageThreshold = .2f;

    private float t;

    private void Update()
    {
        var col = ps.main;
        t = Mathf.InverseLerp(damageThreshold, 1f, health.GetHealthPercentage());

        Color color1 = Color.Lerp(damageColor1, fineColor, t);
        Color color2 = Color.Lerp(damageColor2, fineColor, t);

        ParticleSystem.MinMaxGradient colors = new ParticleSystem.MinMaxGradient(color1, color2);

        col.startColor = colors;
    }
}
