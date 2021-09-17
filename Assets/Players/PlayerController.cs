using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject controlledUnit; // TODO handle when player has no units controlled

    private IPlayerControllable unitInterface;

    private Vector2 rawStickInput;

    private void Start()
    {
        unitInterface = controlledUnit.GetComponent<IPlayerControllable>();
    }

    private void Update()
    {
        unitInterface.OnSteer(rawStickInput);
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        rawStickInput = context.ReadValue<Vector2>();
    }

    public void OnActionA(InputAction.CallbackContext context)
    {
        if (unitInterface != null)
        {
            if (context.performed)
            {
                unitInterface.OnActionA(true);
            }
            else if (context.canceled)
            {
                unitInterface.OnActionA(false);
            }
        }
    }

    public void OnActionB(InputAction.CallbackContext context)
    {
        if (unitInterface != null)
        {
            if (context.performed)
            {
                unitInterface.OnActionB(true);
            }
            else if (context.canceled)
            {
                unitInterface.OnActionB(false);
            }
        }
    }

    public GameObject GetControlledUnit()
    {
        return controlledUnit;
    }
}
