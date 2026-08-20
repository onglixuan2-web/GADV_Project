using UnityEngine;

public class Vine : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 2f;
    [SerializeField] private float lifetime = 5f;

    // A variable used to store the direction that the vine should travel
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
        // Make the vine move continuously
        // Translate moves the vine by a certain amount
        // direction determines which direction the vine moves
        // speed determines how far the vine goes
        // Time.deltaTime makes it a per second movement instead of per frame (movement based on time rather than frame rate)
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // BushMonster.cs calculates the direction of the player and sends it to the vine
    // newDirection receives information on the player's direction from BushMonster.cs
    public void SetDirection(Vector2 newDirection)
    {
        // .normalized converts the direction into a vector with a length of approximately 1
        // Without normalisation, the direction vector of a distant player could be much larger
        // This would cause the vine to move faster towards a player who is further away
        // Normalisation ensures that the speed of the vine does not change, no matter how far the player is
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