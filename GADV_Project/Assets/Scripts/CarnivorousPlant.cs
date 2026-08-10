using UnityEngine;

public class CarnivorousPlant : MonoBehaviour
{
    // Reference to the Animator
    [SerializeField] private Animator anim;
    // Reference to the Box Collider 2D
    [SerializeField] private Collider2D plantCollider;

    // A float that determines the interval between snaps
    [SerializeField] private float snapInterval = 3f;
    // Use waitTimer to ensure that enough time has passed since the last snap
    private float waitTimer;

    // A float that controls the Plant's damage
    [SerializeField] private float damage;

    // Update is called every frame, if the MonoBehaviour is enabled.
    private void Update() 
    {
        // Increment waitTimer on every frame by Time.deltaTime
        waitTimer += Time.deltaTime;

        // If waitTimer >= snapInterval, enough time has passed to allow the next snap
        if(waitTimer >= snapInterval)
        {
            // Play the Snapping animation
            anim.Play("Snapping", 0, 0f);
            // waitTimer will be reset to 0 after each snap
            waitTimer = 0f;
        }

        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);

        // Check if the Snapping animation is running or if it has finished. If it is running, enable the collider, else, disable it.
        // state.IsName("Snapping") only checksthe state name.
        // The Animator only has one state, Snapping, so it will stay in the "Snapping" state even after the animation finishes
        // Add normalizedTime to fix this. When normalizedTime = 1.0, the animation has finished.
        // So if normalizedTime is less than 1.0, the animation is still running
        if(state.IsName("Snapping") && state.normalizedTime < 1f)
        {
            // Enable the collider
            plantCollider.enabled = true;
        }
        else
        {
            // Disable the collider
            plantCollider.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the tag of collided object is "Player"
        if(collision.gameObject.CompareTag("Player"))
        {
            // Player will take damage
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
