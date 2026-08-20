using UnityEngine;

public class Boulder : MonoBehaviour
{
    [SerializeField] private float lifetime = 5f;

    private void Start()
    {
        // Destroy the boulder after its lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            if(playerHealth != null)
            {
                playerHealth.Die();
            }

            Destroy(gameObject);
        }
    }
}
