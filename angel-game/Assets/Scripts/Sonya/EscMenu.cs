using UnityEngine;
using UnityEngine.SceneManagement;


public class EscMenu : MonoBehaviour
{
    public GameObject canvas;

    private void Start()
    {
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    private void QuitGame()
    {
        Application.Quit();

    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
       // FindObjectOfType<AudioManager>().Play("button");
    }
}

