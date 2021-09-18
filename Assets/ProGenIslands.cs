using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProGenIslands : MonoBehaviour
{
    [SerializeField] private RuleTile baseTerrainTile;

    private Tilemap tilemap;

    private float perlinScale = 20f;

    private int size;

    private int offset;

    private void Start()
    {
        size = Mathf.RoundToInt(WorldWrapManager.instance.GetWorldDimensions().x);
        offset = -size / 2;
        tilemap = GetComponent<Tilemap>();
        tilemap.ClearAllTiles();
        GenerateTilemap();
        CleanupSeams();
    }

    public void GenerateTilemap()
    {
        for (int y = 0; y < size - 1; y++)
        {
            for (int x = 0; x < size - 1; x++)
            {
                float xCoord = (float)x / size * perlinScale;
                float yCoord = (float)y / size * perlinScale;

                if (Mathf.RoundToInt(Mathf.PerlinNoise(xCoord, yCoord)) == 0)
                {
                    tilemap.SetTile(new Vector3Int(x + offset, y + offset, 0), baseTerrainTile);
                }
            }
        }
    }

    private void CleanupSeams()
    {
        for (int x = 0; x < size; x++)
        {
            if (tilemap.GetTile(new Vector3Int(x + offset, offset, 0)) != null)
            {
                // Extend bottom row
                tilemap.SetTile(new Vector3Int(x + offset, offset - 1, 0), baseTerrainTile);

                // Duplicate to 1 row above top row
                tilemap.SetTile(new Vector3Int(x + offset, offset + size, 0), baseTerrainTile);

                // Add to top row
                tilemap.SetTile(new Vector3Int(x + offset, offset + size - 1, 0), baseTerrainTile);
            }
        }

        for (int y = 0; y < size; y++)
        {
            if (tilemap.GetTile(new Vector3Int(offset, y + offset, 0)) != null)
            {
                // Extend right column
                tilemap.SetTile(new Vector3Int(offset - 1, y + offset, 0), baseTerrainTile);

                // Duplicate to 1 column left of left-most row
                tilemap.SetTile(new Vector3Int(offset + size, y + offset, 0), baseTerrainTile);

                // Add to left-most row
                tilemap.SetTile(new Vector3Int(offset + size - 1, y + offset, 0), baseTerrainTile);
            }
        }
    }
}
