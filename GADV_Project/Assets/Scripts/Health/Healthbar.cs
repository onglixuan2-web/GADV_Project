using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Reference to player health
    [SerializeField] private Health playerHealth;
    // Reference to HealthbarTotal image
    [SerializeField] private Image totalHealthbar;
    // Reference to the HealthbarCurrent image
    [SerializeField] private Image currentHealthbar;

    private void Start()
    {
        totalHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        // Allow the current healthbar to be updated continuously
        currentHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }
}
