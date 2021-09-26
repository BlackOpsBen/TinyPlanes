using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountTurret : MonoBehaviour
{
    [SerializeField] Transform mount;

    private float offset;

    private void Start()
    {
        offset = Vector2.Distance(mount.position, transform.position);
    }

    private void Update()
    {
        transform.position = new Vector2(mount.position.x, mount.position.y + offset);
    }
}
