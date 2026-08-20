using UnityEngine;
using System.Collections;

public class CrumblingPlatform : MonoBehaviour
{
    [SerializeField] private float crumbleDelay = 0.15f;

    private Rigidbody2D[] crumblePieces;
    private bool hasCrumbled = false;

    private void Awake()
    {
        // Get all Rigidbody2D components from the child objects
        crumblePieces = GetComponentsInChildren<Rigidbody2D>();

        // Keep all pieces stationary in the beginning
        foreach(Rigidbody2D piece in crumblePieces)
        {
            // Change the Rigidbody type of all crumble pieces to Kinematic
            // This will prevent them from falling
            piece.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the trigger has collided with the Player and if the platform has not crumbled
        if(collision.gameObject.CompareTag("Player") && !hasCrumbled)
        {
            hasCrumbled = true;

            StartCoroutine(Crumble());
        }
    }

    private IEnumerator Crumble()
    {
        foreach(Rigidbody2D piece in crumblePieces)
        {
            // Turn this piece into a physics object
            // Change the Rigidbody type of the crumble piece to Dynamic so that it will fall
            piece.bodyType = RigidbodyType2D.Dynamic;

            // Wait before the next piece falls
            yield return new WaitForSeconds(crumbleDelay);
        }
    }
}
