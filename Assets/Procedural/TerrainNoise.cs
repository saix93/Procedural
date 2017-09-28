using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainNoise : MonoBehaviour
{
    private void Start()
    {
        CreateTerrain(512);
    }

    float[,] GenerateWallData(int resolution)
    {
        float[,] values = new float[resolution, resolution];

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                float perlin = Mathf.PerlinNoise(x, y);
                values[x, y] = perlin;
            }
        }

        return values;
    }

    GameObject CreateTerrain(int resolution)
    {
        GameObject terrainGO = new GameObject("Terrain");
        Terrain terrain = terrainGO.AddComponent<Terrain>();
        // TerrainData data = terrain.terrainData;
        TerrainData data = new TerrainData();

        data.size = Vector3.one * resolution;
        data.heightmapResolution = resolution;
        data.SetHeights(resolution, resolution, GenerateWallData(resolution));

        terrain.terrainData = data;
        return terrainGO;
    }
}
