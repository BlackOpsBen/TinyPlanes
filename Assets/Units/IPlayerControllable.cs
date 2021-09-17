using UnityEngine;

public interface IPlayerControllable
{
    public void OnSteer(Vector2 input);

    public void OnActionA(bool isPressed);

    public void OnActionB(bool isPressed);
}
