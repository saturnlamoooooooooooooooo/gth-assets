using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerManager : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to be spawned
    public List<Transform> spawnPoints; // List of spawn points
    public float minSpawnDelay = 1.0f; // Minimum time to wait before spawning
    public float maxSpawnDelay = 5.0f; // Maximum time to wait before spawning

    private void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (true)
        {
            // Wait for a random delay before spawning the prefab
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            // Randomly select a spawn point from the list
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[randomIndex];

            // Spawn the prefab at the chosen spawn point
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);


        }
    }
}