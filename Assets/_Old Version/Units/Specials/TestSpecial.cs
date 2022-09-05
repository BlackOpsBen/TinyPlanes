using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpecial : MonoBehaviour, ISpecialAbility
{
    public void OnSpecial(bool performed, bool canceled)
    {
        if (performed)
        {
            Debug.Log("Test Special Ability used.");
        }
    }
}
