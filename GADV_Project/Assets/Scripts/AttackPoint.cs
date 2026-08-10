using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private PlayerAttack playerAttack;
    private bool hasHit;

    private void Awake()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();

        Debug.Log("AttackPoint Awake!");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!playerAttack.IsAttacking())
        {
            return;
        }

        if (collision.CompareTag("Enemy") && !hasHit)
        {
            EnemyHealth enemyHealth = collision.GetComponentInParent<EnemyHealth>();

            if (enemyHealth != null)
            {
                Debug.Log("Enemy Health found!");

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
