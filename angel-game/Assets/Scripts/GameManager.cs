using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsMinigameOpen;
    public bool IsDead;
    public bool IsMenuOpen;

    public static bool IsFirstGame = true;

    private bool _isPaused;

    public Action OnPlayerDead;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (IsFirstGame)
            StopGameTimer();
        else
            StartGameTimer();
    }

    private void Start()
    {
        OnPlayerDead += Death;
    }

    public void StartGameTimer()
    {
        Time.timeScale = 1;
    }

    public void StopGameTimer()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (IsDead && Input.GetKeyDown(KeyCode.Return))
            RestartGame();
    }

    private void Death()
    {
        IsDead = true;
        IsFirstGame = false;
        StopGameTimer();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}