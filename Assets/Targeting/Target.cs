using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private bool isActive = true;

    /// <summary>
    /// Sets the RigidBody2D that is associated with this target.
    /// </summary>
    /// <param name="rb"></param>
    public void SetRigidBody(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    /// <summary>
    /// Gets the RigidBody2D that is associated with this target.
    /// </summary>
    /// <returns></returns>
    public Rigidbody2D GetRigidBody()
    {
        return rb;
    }

    public void SetIsActive(bool isActive)
    {
        this.isActive = isActive;
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}
