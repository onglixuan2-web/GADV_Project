using UnityEngine;

public class FireMonster : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float range = 20f;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform fireballSpawner;

    private Animator anim;
    private Transform player;

    // Use cooldownTimer to ensure that enough time has passed since the last attack
    // When the game starts, cooldownTimer = 0, player cannot attack straight away
    // Setting cooldownTimer to Mathf.Infinity will resolve that issue
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if(playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        // Increment cooldownTimer on every frame by Time.deltaTime
        cooldownTimer += Time.deltaTime;

        if(player == null)
            return;

        // Calculate the distance between the Fire Monster and the Player
        // Vector2 gives the distance between 2 points
        float distance = Vector2.Distance(transform.position, player.position);

        // Check if distance between Fire Monster and Player <= Fire Monster's attack range
        // AND if time passed after previous attack >= Fire Monster's attack cooldown
        if(distance <= range && cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");

        // cooldownTimer will be reset to 0 after each attack
        cooldownTimer = 0f;
    }

    public void ShootFireball()
    {
        // Create a new copy of the fireball game object, using Instantiate
        // What to create -> fireballPrefab 
        // Where to create the object -> fireballSpawner.position
        // What rotation -> Quaternion.identity (Default/no rotation)
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawner.position, Quaternion.identity);

        Fireball fireballScript = fireball.GetComponent<Fireball>();

        // Find the direction that the fireball needs to travel from the spawner to reach the player
        // Subtract the 2 Vectors (player's position and fireball spawner's position) to find the direction
        Vector2 direction = player.position - fireballSpawner.position;

        // Pass the calculated direction into the fireball script, so that the fireball will travel in that direction
        fireballScript.SetDirection(direction);
    }
}
