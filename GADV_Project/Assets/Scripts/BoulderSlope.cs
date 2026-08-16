using UnityEngine;

public class BoulderSlope : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boulder"))
        {
            Destroy(gameObject, lifetime);
        }
    }
}
