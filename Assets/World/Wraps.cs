using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraps : MonoBehaviour
{
    [Tooltip("If enabled, this object will be targetable by wrapping around map.")]
    [SerializeField] private bool wrapTarget;
    [SerializeField] private GameObject targetWrapGroupPrefab;

    private Vector2 worldSize;

    private void Start()
    {
        worldSize = WorldWrapManager.instance.GetWorldDimensions();

        if (wrapTarget)
        {
            //List<Vector2> targetPositions = WorldWrapManager.instance.GetWrapTargetPositions(transform.position);

            //foreach (var tPos in targetPositions)
            //{
            //    GameObject g = Instantiate(new GameObject(), WorldWrapManager.instance.transform, false);
            //    g.tag = gameObject.tag;
            //    g.transform.position = tPos;
            //}

            Transform parent = GameObject.FindGameObjectWithTag("TargetWrapGroups").transform;
            GameObject group = Instantiate(targetWrapGroupPrefab, parent, true);
            group.GetComponent<ConstrainToParentTarget>().SetParent(transform);
        }
    }

    private void Update()
    {
        WrapPosition();
    }

    private void WrapPosition()
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
