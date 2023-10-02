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
        Time.timeScale = 0;
        canvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        // FindObjectOfType<AudioManager>().Play("button");
    }
    
    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
        canvas.SetActive(false);
    }
}