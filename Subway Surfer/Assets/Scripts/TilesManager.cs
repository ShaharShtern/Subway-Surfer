using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefabs;
    [SerializeField] private int numberOfTiles = 5;
    [SerializeField] private float tileLength = 20;
    [SerializeField] private float zSpawnPosition = 0;
    [SerializeField] private Transform player;
    [SerializeField] private int distanceBetweenTiles;
    private List<GameObject> activeTiles = new List<GameObject>();

    private void Start()
    {
        SpawnTile(0);
        SpawnTile(0);
        for (int i = 0; i < numberOfTiles; i++)
        {
            int index = Random.Range(1, tilePrefabs.Length);
            SpawnTile(index);
        }
    }
    private void Update()
    {
        if (player.position.z + distanceBetweenTiles > zSpawnPosition)
        {
            int index = Random.Range(1, tilePrefabs.Length);
            SpawnTile(index);
            DeleteFirstTile();
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject newTile;
        newTile = Instantiate(
            tilePrefabs[tileIndex],
            transform.forward * zSpawnPosition,
            Quaternion.identity);

        zSpawnPosition += tileLength;

        activeTiles.Add(newTile);
    }
    private void DeleteFirstTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
