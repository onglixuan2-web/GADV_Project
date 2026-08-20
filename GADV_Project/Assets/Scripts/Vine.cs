using UnityEngine;

public class Vine : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 2f;
    [SerializeField] private float lifetime = 5f;

    private Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Destroy the vine after its lifetime 
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    private void Update()
    {
        // Make the vine move in the calculated direction, at its movement speed
        // Time.deltaTime makes it a per second movement instead of per frame
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 newDirection)
    {
        // Get the calculated direction between the player and the vine spawner
        direction = newDirection.normalized;
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