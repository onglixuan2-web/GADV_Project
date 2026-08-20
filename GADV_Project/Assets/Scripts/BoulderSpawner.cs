using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boulderPrefab;
    [SerializeField] private Transform spawnPoint;

    public void SpawnBoulder()
    {
        // Create a copy of the boulder prefab at the spawn point
        Instantiate(boulderPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
