using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IAbility
{
    void UseAbility(InputAction.CallbackContext context);
}
