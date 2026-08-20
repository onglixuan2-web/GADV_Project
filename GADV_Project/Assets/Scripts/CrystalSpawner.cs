using UnityEngine;

public class CrystalSpawner : MonoBehaviour
   {
    [SerializeField] private GameObject crystalPrefab;
    // Create an array of Transform references to store multiple spawn points
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 1f;

    // Keep track of how much time has passed since the last crystal was spawned
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
        // Choose a random spawn point, based on its index in the spawnPoints array
        // The range is between 0 and the number of spawn points stored in the array
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Get the selected spawn point
        Transform spawnPoint = spawnPoints[randomIndex];

        // Create a copy of the crystal prefab at the selected spawn point
        Instantiate(crystalPrefab, spawnPoint.position, spawnPoint.rotation);
    }
   }
