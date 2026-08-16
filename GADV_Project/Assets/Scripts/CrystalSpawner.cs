using UnityEngine;

public class CrystalSpawner : MonoBehaviour
   {
    [SerializeField] private GameObject crystalPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 1f;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnInterval)
        {
            SpawnCrystal();

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
