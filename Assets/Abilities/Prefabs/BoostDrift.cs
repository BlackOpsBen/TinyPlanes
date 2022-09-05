using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoostDrift : MonoBehaviour, IAbility
{
    public void UseAbility(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Performed Boost Drift");
        }
        else if (context.canceled)
        {
            Debug.Log("Cancelled Boost Drift");
        }
    }
}
