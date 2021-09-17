using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Steering))]
[RequireComponent(typeof(Arsenal))]
[RequireComponent(typeof(ISpecialAbility))]
public class PlaneInterface : MonoBehaviour, IPlayerControllable
{
    private Steering steering;
    private Arsenal arsenal;
    private ISpecialAbility special;

    private void Awake()
    {
        steering = GetComponent<Steering>();
        arsenal = GetComponent<Arsenal>();
        special = GetComponent<ISpecialAbility>();
    }

    public void OnSteer(Vector2 input)
    {
        steering.OnSteer(input);
    }

    public void OnActionA(bool isPressed)
    {
        arsenal.OnShoot(isPressed);
    }

    public void OnActionB(bool isPressed)
    {
        special.OnSpecial(isPressed);
    }
}
