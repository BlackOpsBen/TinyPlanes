using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWrapManager : MonoBehaviour
{
    public static WorldWrapManager instance;

    private void Awake()
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
    [SerializeField] private Vector2 worldDimensions = new Vector2(10f, 10f);

    [Header("World Objects")]
    [SerializeField] private Camera worldMapCamera;
    [SerializeField] private GameObject[] worldMapCopies;

    private void Start()
    {
        UpdateWorldWrap();
    }

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

            //t.position = new Vector3(t.position.x * worldDimensions.x / Mathf.Abs(t.position.x), t.position.y * worldDimensions.y / Mathf.Abs(t.position.y), t.position.z);

            float xPos;
            float yPos;

            if (t.position.x != 0f)
            {
                xPos = Mathf.Sign(t.position.x) * worldDimensions.x;
            }
            else
            {
                xPos = 0f;
            }

            if (t.position.y != 0f)
            {
                yPos = Mathf.Sign(t.position.y) * worldDimensions.y;
            }
            else
            {
                yPos = 0f;
            }

            t.position = new Vector3(xPos, yPos, t.position.z);
        }
    }
}
