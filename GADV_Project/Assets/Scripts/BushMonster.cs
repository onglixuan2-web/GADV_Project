using UnityEngine;

public class BushMonster : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float range = 10f;
    [SerializeField] private GameObject vinePrefab;
    [SerializeField] private Transform vineSpawner;

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

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        // Increment cooldownTimer on every frame by Time.deltaTime
        cooldownTimer += Time.deltaTime;

        if (player == null)
            return;

        // Calculate the distance between the Bush Monster and the Player
        // Vector2 gives the distance between 2 points
        float distance = Vector2.Distance(transform.position, player.position);

        // Check if distance between Bush Monster and Player <= Bush Monster's attack range
        // AND if time passed after previous attack >= Bush Monster's attack cooldown
        if (distance <= range && cooldownTimer >= attackCooldown)
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

    public void ShootVine()
    {
        // Create a new copy of the vine game object, using Instantiate
        // What to create -> vinePrefab 
        // Where to create the object -> vineSpawner.position
        // What rotation -> Quaternion.identity (Default/no rotation)
        GameObject vine = Instantiate(vinePrefab, vineSpawner.position, Quaternion.identity);

        Vine vineScript = vine.GetComponent<Vine>();

        // Find the direction that the vine needs to travel from the spawner to reach the player
        // Subtract the 2 Vectors (player's position and vine spawner's position) to find the direction
        Vector2 direction = player.position - vineSpawner.position;

        // Pass the calculated direction into the vine script, so that the vine will travel in that direction
        vineScript.SetDirection(direction);
    }
}
