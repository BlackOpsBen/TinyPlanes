using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProGenIslands : MonoBehaviour
{
    [SerializeField] private RuleTile baseTerrainTile;

    private Tilemap tilemap;

    [SerializeField] private float[] additivePerlinScales;
    [SerializeField] private float[] multiplicativePerlinScales;
    private float[] addRandOffsets;
    private float[] multiplyRandOffsets;

    private int size;

    private int offset;

    private void Start()
    {
        addRandOffsets = new float[additivePerlinScales.Length];
        multiplyRandOffsets = new float[multiplicativePerlinScales.Length];

        for (int i = 0; i < addRandOffsets.Length; i++)
        {
            addRandOffsets[i] = UnityEngine.Random.Range(0f, 100f);
        }

        for (int i = 0; i < multiplyRandOffsets.Length; i++)
        {
            multiplyRandOffsets[i] = UnityEngine.Random.Range(0f, 100f);
        }

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
                float finalVal = 0f;
                for (int i = 0; i < additivePerlinScales.Length; i++)
                {
                    float xCoord = (float)x / size * additivePerlinScales[i] + addRandOffsets[i];
                    float yCoord = (float)y / size * additivePerlinScales[i] + addRandOffsets[i];
                    finalVal += Mathf.RoundToInt(Mathf.PerlinNoise(xCoord, yCoord));
                    finalVal = Mathf.Clamp01(finalVal);
                }

                for (int i = 0; i < multiplicativePerlinScales.Length; i++)
                {
                    float xCoord = (float)x / size * multiplicativePerlinScales[i] + multiplyRandOffsets[i];
                    float yCoord = (float)y / size * multiplicativePerlinScales[i] + multiplyRandOffsets[i];
                    finalVal *= Mathf.RoundToInt(Mathf.PerlinNoise(xCoord, yCoord));
                }
                //float xCoord = (float)x / size * additivePerlinScales;
                //float yCoord = (float)y / size * additivePerlinScales;

                if (Mathf.RoundToInt(finalVal) == 1)
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
