using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 2f; // This will represent the amount of time that needs to pass before the next attack
    [SerializeField] private float damage = 2f;
    [SerializeField] private AttackPoint attackPoint;

    private Animator anim; // Reference to the Animator
    private PlayerMovement playerMovement; // Reference to the PlayerMovement component
    private bool isAttacking;

    // Use cooldownTimer to ensure that enough time has passed since the last attack
    // When the game starts, cooldownTimer = 0, player cannot attack straight away
    // Setting cooldownTimer to Mathf.Infinity will resolve that issue
    private float cooldownTimer = Mathf.Infinity; 

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // Use GetComponent to get references to the Animator and PlayerMovement
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called every frame, if the MonoBehaviour is enabled.
    private void Update() 
    {
        // Check if left mouse button is pressed
        // Check if the cooldownTimer > attackCooldown
        // Check if the player is in a state that allows them to attack
        // If cooldownTimer > attackCooldown, enough time has passed to allow the next attack
        // If all conditions are met, the Attack() method will be called
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        // Increment cooldownTimer on every frame by Time.deltaTime
        cooldownTimer += Time.deltaTime;
    }

    // Attack method
    private void Attack()
    {
        isAttacking = true;
        attackPoint.ResetHit();
        // Play the attack animation when attacking
        anim.SetTrigger("Attack");
        // cooldownTimer will be reset to 0 after each attack
        cooldownTimer = 0;
    }

    public float GetDamage()
    {
        return damage;
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}
