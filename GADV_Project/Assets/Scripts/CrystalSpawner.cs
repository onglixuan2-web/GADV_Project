using UnityEngine;

public class CrystalSpawner : MonoBehaviour
   {
    [SerializeField] private GameObject crystalPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 1f;

    private float spawnTimer;

    private void Update()
    {
        // Increment the spawnTimer by the time taken to finish the previous frame
        spawnTimer += Time.deltaTime;

        // Check if the time passed after the crystal spawned >= crystal's spawn interval (time between each spawn)
        if(spawnTimer >= spawnInterval)
        {
            SpawnCrystal();

            // Reset spawn timer to 0
            spawnTimer = 0f;
        }
    }

    private void SpawnCrystal()
    {
        // Choose a random spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[randomIndex];

        // Spawn the crystal
        Instantiate(crystalPrefab, spawnPoint.position, spawnPoint.rotation);
    }
   }
