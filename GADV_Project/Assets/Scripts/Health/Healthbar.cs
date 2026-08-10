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

    // Start is called before the first frame update.
    private void Start()
    {
        totalHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        // Allow the current healthbar to be updated continuously
        currentHealthbar.fillAmount = playerHealth.currentHealth / 10;
    }
}
