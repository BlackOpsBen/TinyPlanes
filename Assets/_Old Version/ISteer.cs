using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISteer
{
    void OnSteer(Vector2 rawLeftInput);
}
