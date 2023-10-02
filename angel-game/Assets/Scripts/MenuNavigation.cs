using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;

    private void Start()
    {
        if (GameManager.IsFirstGame)
            OpenStartMenu();

        GameManager.Instance.OnPlayerDead += ShowGameOverMenu;
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

    public void StartGame()
    {
        GameManager.Instance.IsMenuOpen = false;
        GameManager.Instance.StartGameTimer();
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        GameManager.IsFirstGame = false;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPlayerDead -= ShowGameOverMenu;
    }
}