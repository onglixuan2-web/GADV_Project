using UnityEngine;

public class BushMonster : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float range = 10f;
    [SerializeField] private GameObject vinePrefab;
    [SerializeField] private Transform vineSpawner;

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

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (player == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= range && cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");

        cooldownTimer = 0f;
    }

    public void ShootVine()
    {
        GameObject vine = Instantiate(vinePrefab, vineSpawner.position, Quaternion.identity);

        Vine vineScript = vine.GetComponent<Vine>();

        Vector2 direction = player.position - vineSpawner.position;

        vineScript.SetDirection(direction);
    }
}
