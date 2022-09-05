using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWrapManager : MonoBehaviour
{
    public static WorldWrapManager instance;

    private void Awake()
    {
        worldDimensions.y = worldDimensions.x;
        SingletonPattern();
        UpdateWorldWrap();
    }

    private void SingletonPattern()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    [Header("Settings")]
    [Tooltip("Currently must be a square. Y will be set equal to X at runtime.")]
    [SerializeField] private Vector2 worldDimensions = new Vector2(10f, 10f);

    [Header("World Objects")]
    [SerializeField] private Camera worldMapCamera;
    [SerializeField] private GameObject[] worldMapCopies;

    public Vector2 GetWorldDimensions()
    {
        return worldDimensions;
    }

    public void UpdateWorldWrap()
    {
        worldMapCamera.orthographicSize = worldDimensions.y / 2;

        for (int i = 0; i < worldMapCopies.Length; i++)
        {
            Transform t = worldMapCopies[i].transform;

            t.localScale = new Vector3(worldDimensions.x, worldDimensions.y, t.localScale.z); ;

            t.position = GetWrappedPosition(t.position);
        }
    }

    public static Vector3 GetWrappedPosition(Vector3 position)
    {
        Vector2 origin = new Vector2(0f, 0f);
        float xPos;
        float yPos;

        if (Mathf.Abs(position.x - origin.x) > float.Epsilon)
        {
            xPos = Mathf.Sign(position.x) * instance.worldDimensions.x;
        }
        else
        {
            xPos = origin.x;
        }

        if (Mathf.Abs(position.y - origin.y) > float.Epsilon)
        {
            yPos = Mathf.Sign(position.y) * instance.worldDimensions.y;
        }
        else
        {
            yPos = origin.y;
        }

        return new Vector3(xPos, yPos, position.z);
    }

    //public List<Vector2> GetWrapTargetPositions(Vector2 ownerPosition)
    //{
    //    List<Vector2> targetPositions = new List<Vector2>();

    //    for (int i = 0; i < worldMapCopies.Length; i++)
    //    {
    //        Vector2 position = (Vector2)worldMapCopies[i].transform.position + ownerPosition;
    //        targetPositions.Add(position);
    //    }

    //    return targetPositions;
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(Vector3.zero, worldDimensions);
    }
}
