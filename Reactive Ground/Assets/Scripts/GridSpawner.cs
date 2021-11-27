using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] tilesToSpawn;
    public int gridX, gridZ, gridY;
    [SerializeField] float gridSpacingOffeset = 1.0f;
    [SerializeField] Vector3 gridOrigin = Vector3.zero;

    void Start()
    {
        SpawnGrid();
    }

    public void SpawnGrid()
    {
        for(int x = 0; x < gridX; x++)
        {
            for(int z = 0; z < gridZ; z++)
            {
                for(int y = 0; y < gridY; y++)
                {
                    Vector3 spawnPosition = new Vector3(x * gridSpacingOffeset, y * gridSpacingOffeset, z * gridSpacingOffeset) + gridOrigin;
                    SpawnTheseObjects(spawnPosition, Quaternion.identity);
                }
            }
        }
    }

    private void SpawnTheseObjects(Vector3 positionToSpawn, Quaternion roationToSpawn)
    {
        int randomIndex = Random.Range(0, tilesToSpawn.Length);
        GameObject clone = Instantiate(tilesToSpawn[randomIndex], positionToSpawn, roationToSpawn);
    }
}
