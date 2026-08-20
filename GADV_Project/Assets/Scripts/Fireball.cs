using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float lifetime = 5f;

    private Vector2 direction;

    private void Start()
    {
        // Destroy the fireball after its lifetime 
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Make the fireball move in the calculated direction, at its movement speed
        // Time.deltaTime makes it a per second movement instead of per frame
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 newDirection)
    {
        // Get the calculated direction between the player and the fireball spawner
        direction = newDirection.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();

            if(playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
