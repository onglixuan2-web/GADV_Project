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
            piece.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Detected!");

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
            Debug.Log("Pieces are now Dynamic!");

            // Turn this piece into a physics object
            piece.bodyType = RigidbodyType2D.Dynamic;

            // Wait before the next piece falls
            yield return new WaitForSeconds(crumbleDelay);
        }
    }
}
