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

    private GameObject controllingPlayer;

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

    public void OnActionA(bool performed, bool canceled)
    {
        arsenal.OnShoot(performed, canceled);
    }

    public void OnActionB(bool performed, bool canceled)
    {
        special.OnSpecial(performed, canceled);
    }

    public void SetControllingPlayer(GameObject controllingPlayer)
    {
        this.controllingPlayer = controllingPlayer;
    }

    public GameObject GetControllingPlayer()
    {
        return controllingPlayer;
    }
}
