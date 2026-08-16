using UnityEngine;

public class CrystalShard : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float lifetime = 5f;

    private void Start()
    {
        // Destroy the crystal after a few seconds (lifetime)
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
