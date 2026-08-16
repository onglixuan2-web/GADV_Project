using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boulderPrefab;
    [SerializeField] private Transform spawnPoint;

    public void SpawnBoulder()
    {
        Instantiate(boulderPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
