using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform muzzle;

    private Transform projectileParent;

    private Arsenal arsenal;

    private float timer = 0f;

    private bool isShooting = false;

    private void Awake()
    {
        projectileParent = GameObject.FindGameObjectWithTag("Projectiles").transform;
        arsenal = GetComponent<Arsenal>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float fireThreshold = 1f / arsenal.GetCurrentWeapon().GetPerSecondRate();

        if (isShooting && timer >= fireThreshold)
        {
            timer = 0f;

            arsenal.GetCurrentWeapon().Shoot(muzzle, projectileParent);
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isShooting = true;
        }
        else if (context.canceled)
        {
            isShooting = false;
        }
    }
}
