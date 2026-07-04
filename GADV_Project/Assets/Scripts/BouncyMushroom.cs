using UnityEngine;

public class BouncyMushroom : MonoBehaviour
{
    // The bounce of the mushroom
    // The higher the value, the higher the player gets accelerated upwards
    private float bounce = 20f;

    // Check if something collided with the mushroom
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the tag of collided object is "Player"
        if(collision.gameObject.CompareTag("Player"))
        {
            // Access the player's Rigidbody 2D component and add a force to it
            // The force applied is defined by the player's desired direction multiplied by the bounce value
            // ForceMode2D.Impulse to apply an instant force
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
}
