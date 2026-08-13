using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    // Amount of health enemy has when starting the game
    [SerializeField] private float startingHealth = 3f;
    // Enemy's current health
    // Making currentHealth public will allow anyone to access it and modify it from other scripts.
    // get allows the variable to be accessed from another script.
    // private set ensures that this variable can only be set in this script.
    public float currentHealth { get; private set; }

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // Initialise current health as starting health
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        Debug.Log("TakeDamage");
        // Use Mathf.Clamp as a safeguard to ensure that the currentHealth does not go below 0.
        // Subtract the damage taken by the player from their current health.
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        // Check if the enemy is dead after taking damage.
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
            // Enemy dead
            Destroy(gameObject);
    }
}

