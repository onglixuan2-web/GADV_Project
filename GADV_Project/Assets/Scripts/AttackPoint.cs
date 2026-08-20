using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private PlayerAttack playerAttack;
    private bool hasHit;

    private void Awake()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

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

    public void ResetHit()
    {
        hasHit = false;
    }

    public bool HasHit()
    {
        return hasHit;
    }
}
