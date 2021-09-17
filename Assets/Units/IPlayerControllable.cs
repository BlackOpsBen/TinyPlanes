using UnityEngine;

public interface IPlayerControllable
{
    public void OnSteer(Vector2 input);

    public void OnActionA(bool performed, bool canceled);

    public void OnActionB(bool performed, bool canceled);
}
