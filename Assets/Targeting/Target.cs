using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public void SetRigidBody(Rigidbody2D rb)
    {
        this.rb = rb;
    }

    public Rigidbody2D GetRigidBody()
    {
        return rb;
    }
}
