using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Amount of health player has when starting the game
    [SerializeField] private float startingHealth;
    // Player's current health
    // Making currentHealth public will allow anyone to access it and modify it from other scripts.
    // get allows the variable to be accessed from another script.
    // private set ensures that this variable can only be set in this script.
    public float currentHealth { get; private set; }

    private void Awake()
    {
        // Initialise current health as starting health
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        // Use Mathf.Clamp as a safeguard to ensure that the currentHealth does not go below 0.
        // Subtract the damage taken by the player from their current health.
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        // Check if the player is dead or still alive after taking damage.
        if(currentHealth > 0)
        {
            // Player hurt
        }
        else
        {
            // Player dead
            // Respawn the player at the starting point.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
