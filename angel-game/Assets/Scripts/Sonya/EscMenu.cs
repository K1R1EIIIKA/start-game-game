using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    public GameObject canvas;

    [SerializeField] private GameObject settingsCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.IsMenuOpen && !GameManager.Instance.IsDead)
        {
            if (canvas.activeSelf)
                Resume();
            else
                Pause();
        }
    }

    private void Pause()
    {
        canvas.SetActive(true);
        GameManager.Instance.StopGameTimer();
        settingsCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        canvas.SetActive(false);
        settingsCanvas.SetActive(false);
        GameManager.Instance.StartGameTimer();
        // FindObjectOfType<AudioManager>().Play("button");
    }

    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
    }
}