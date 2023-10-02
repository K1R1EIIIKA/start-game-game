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

    private void Start()
    {
        if (GameManager.IsFirstGame)
            OpenMenu();
    }

    public void OpenSettings()
    {
        GameManager.Instance.IsMenuOpen = true;
        settingsCanvas.SetActive(true);
        GameManager.Instance.StopGameTimer();
    }

    public void CloseSettings()
    {
        GameManager.Instance.IsMenuOpen = false;
        settingsCanvas.SetActive(false);
    }

    public void OpenMenu()
    {
        GameManager.Instance.IsMenuOpen = true;
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        GameManager.Instance.StopGameTimer();
    }

    public void StartGame()
    {
        GameManager.Instance.IsMenuOpen = false;
        GameManager.Instance.StartGameTimer();
        mainMenuCanvas.SetActive(false);

        GameManager.IsFirstGame = false;
        pauseCanvas.SetActive(false);
        GameManager.Instance.RestartGame();
    }
}
