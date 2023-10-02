using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;

    [SerializeField] private GameObject learningCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        if (GameManager.IsFirstGame)
            OpenStartMenu();

        GameManager.Instance.OnPlayerDead += ShowGameOverMenu;
    }

    private void Update()
    {
        learningCanvas.SetActive(!GameManager.Instance.IsMinigameOpen);
    }

    public void OpenSettings()
    {
        GameManager.Instance.IsMenuOpen = true;
        GameManager.Instance.StopGameTimer();
        settingsCanvas.SetActive(true);
    }

    public void CloseSettings()
    {
        GameManager.Instance.IsMenuOpen = false;
        settingsCanvas.SetActive(false);
    }

    private void ShowGameOverMenu()
    {
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void OpenStartMenu()
    {
        GameManager.Instance.IsMenuOpen = true;
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        GameManager.Instance.StopGameTimer();
    }

    public void StartLearning()
    {
        GameManager.Instance.IsMenuOpen = false;
        GameManager.Instance.StartGameTimer();
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        GameManager.IsFirstGame = false;

        learningCanvas.SetActive(true);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPlayerDead -= ShowGameOverMenu;
    }
}