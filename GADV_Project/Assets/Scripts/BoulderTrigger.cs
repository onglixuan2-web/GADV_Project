using UnityEngine;

public class BoulderTrigger : MonoBehaviour
{
    [SerializeField] private BoulderSpawner boulderSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            boulderSpawner.SpawnBoulder();

            // Destroy the invisible trigger
            Destroy(gameObject);
        }
    }
}
