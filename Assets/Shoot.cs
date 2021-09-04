using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform muzzle;

    private float timer = 0f;

    private bool isShooting = false;

    private void Update()
    {
        timer += Time.deltaTime;

        float fireThreshold = 1f / weapon.GetPerSecondRate();

        if (isShooting && timer >= fireThreshold)
        {
            timer = 0f;

            weapon.Shoot(muzzle);
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
