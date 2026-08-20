using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject endCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Enable endCanvas
            endCanvas.SetActive(true);

            // Time.timeScale controls the speed at which time passes in the game
            // Set Time.timeScale to 0 to pause the game
            Time.timeScale = 0f;
        }
    }

    public void Replay()
    {
        // Set Time.timeScale to 1 to run the game at normal speed
        Time.timeScale = 1f;

        // Load the first scene
        SceneManager.LoadScene(0);
    }
}
