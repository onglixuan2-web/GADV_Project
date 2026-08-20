using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float lifetime = 5f;

    // A variable used to store the direction that the fireball should travel
    private Vector2 direction;

    private void Start()
    {
        // Destroy the fireball after its lifetime ends
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Make the fireball move continuously
        // Translate moves the fireball by a certain amount
        // direction determines which direction the fireball moves
        // speed determines how far the fireball goes
        // Time.deltaTime makes it a per second movement instead of per frame (movement based on time rather than frame rate)
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // FireMonster.cs calculates the direction of the player and sends it to the fireball
    // newDirection receives information on the player's direction from FireMonster.cs
    public void SetDirection(Vector2 newDirection)
    {
        // .normalized converts the direction into a vector with a length of approximately 1
        // Without normalisation, the direction vector of a distant player could be much larger
        // This would cause the fireball to move faster towards a player who is further away
        // Normalisation ensures that the speed of the fireball does not change, no matter how far the player is
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
