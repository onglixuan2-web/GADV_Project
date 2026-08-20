using UnityEngine;

public class Abyss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the Abyss collided with the Player
        if(collision.gameObject.CompareTag("Player"))
        {
            // Get the player's Health component
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            if (playerHealth != null)
            {
                // Call the Die() function from the Health script
                playerHealth.Die();
            }
        }
    }
}
