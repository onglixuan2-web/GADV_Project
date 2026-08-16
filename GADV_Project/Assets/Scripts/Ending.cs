using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject endCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            endCanvas.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void Replay()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
}
