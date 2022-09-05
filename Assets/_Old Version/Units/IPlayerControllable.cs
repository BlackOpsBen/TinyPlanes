using UnityEngine;

public interface IPlayerControllable
{
    public void SetControllingPlayer(GameObject controllingPlayer);

    public GameObject GetControllingPlayer();

    public void OnSteer(Vector2 input);

    public void OnActionA(bool performed, bool canceled);

    public void OnActionB(bool performed, bool canceled);
}
