using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapPosition : MonoBehaviour
{
    private Vector2 worldSize;

    private void Start()
    {
        worldSize = WorldWrapManager.instance.GetWorldDimensions();
    }

    private void Update()
    {
        SetWrappedPosition();
    }

    private void SetWrappedPosition()
    {
        if (transform.position.x < -worldSize.x / 2)
        {
            transform.position = new Vector3(transform.position.x + worldSize.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x > worldSize.x / 2)
        {
            transform.position = new Vector3(transform.position.x - worldSize.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -worldSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + worldSize.y, transform.position.z);
        }

        if (transform.position.y > worldSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - worldSize.y, transform.position.z);
        }
    }
}
