using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTargetWrapOffsets : MonoBehaviour
{
    [SerializeField] private Transform[] offsets;

    public void Init(Rigidbody2D rb, string tag)
    {
        for (int i = 0; i < offsets.Length; i++)
        {
            offsets[i].position = WorldWrapManager.GetWrappedPosition(offsets[i].position);
            offsets[i].GetComponent<Target>().SetRigidBody(rb);
            offsets[i].tag = tag;
        }
    }
}
