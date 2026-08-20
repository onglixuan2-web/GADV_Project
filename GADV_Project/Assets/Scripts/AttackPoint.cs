using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private PlayerAttack playerAttack;
    private bool hasHit; // Check whether an enemy has been hit

    private void Awake()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    // OnTriggerEnter2D -> Runs once, at the exact moment when the 2 colliders touch
    // OnTriggerStay2D -> Runs continuously while the 2 colliders are overlapping
    // OnTriggerEnter2D -> Player has to move away and touch the enemy again, to attack them again
    // OnTriggerStay2D -> Player can continuously attack the enemy without having to walk away and come back
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the player is not attacking
        if (!playerAttack.IsAttacking())
        {
            return;
        }

        // Check if the Player collided with an Enemy and has not hit the enemy
        if (collision.CompareTag("Enemy") && !hasHit)
        {
            EnemyHealth enemyHealth = collision.GetComponentInParent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // Subtract the player's damage from the enemy's health
                enemyHealth.TakeDamage(playerAttack.GetDamage());

                hasHit = true;
            }
        }
    }

    // Reset hasHit to false
    public void ResetHit()
    {
        hasHit = false;
    }

    public bool HasHit()
    {
        return hasHit;
    }
}
