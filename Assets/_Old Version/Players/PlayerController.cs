using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameObject controlledUnit;

    private IPlayerControllable unitInterface;

    public void OnSteer(InputAction.CallbackContext context)
    {
        if (unitInterface != null)
        {
            unitInterface.OnSteer(context.ReadValue<Vector2>());
        }
    }

    public void OnAISteer(Vector2 input)
    {
        if (unitInterface != null)
        {
            unitInterface.OnSteer(input);
        }
    }

    public void OnActionA(InputAction.CallbackContext context)
    {
        if (unitInterface != null)
        {
            if (context.performed)
            {
                unitInterface.OnActionA(true, false);
            }
            else if (context.canceled)
            {
                unitInterface.OnActionA(false, true);
            }
        }
    }

    public void OnAIActionA(bool performed, bool canceled)
    {
        if (unitInterface != null)
        {
            unitInterface.OnActionA(performed, canceled);
        }
    }

    public void OnActionB(InputAction.CallbackContext context)
    {
        if (unitInterface != null)
        {
            if (context.performed)
            {
                unitInterface.OnActionB(true, false);
            }
            else if (context.canceled)
            {
                unitInterface.OnActionB(false, true);
            }
        }
    }

    public void OnAIActionB(bool performed, bool canceled)
    {
        if (unitInterface != null)
        {
            unitInterface.OnActionB(performed, canceled);
        }
    }

    public GameObject GetControlledUnit()
    {
        return controlledUnit;
    }

    /// <summary>
    /// Warning: argument must have a component that implements IPlayerControllable
    /// </summary>
    /// <param name="unit"></param>
    public void SetControlledUnit(GameObject unit)
    {
        controlledUnit = unit;
        unitInterface = controlledUnit.GetComponent<IPlayerControllable>();
        unitInterface.SetControllingPlayer(gameObject);
    }
}
