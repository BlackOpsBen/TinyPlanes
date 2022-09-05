using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour, IAbility
{
    public void UseAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Performed Shoot");
        }
        else if (context.canceled)
        {
            Debug.Log("Cancelled Shoot");
        }
    }
}
