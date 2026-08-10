using UnityEngine;

public class FireMonster : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float range = 5f;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform fireballSpawner;

    private Animator anim;
    private Transform player;

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
        cooldownTimer += Time.deltaTime;

        if(player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if(distance <= range && cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        
        cooldownTimer = 0f;
    }

    public void ShootFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawner.position, Quaternion.identity);

        Fireball fireballScript = fireball.GetComponent<Fireball>();

        Vector2 direction = player.position - fireballSpawner.position;

        fireballScript.SetDirection(direction);
    }
}
