using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject gameOverCanvas;

    public bool IsMinigameOpen;
    public bool IsDead;
    public bool IsMenuOpen;
    
    public static bool IsFirstGame = true;

    private bool _isPaused;

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
        if (MainHp.Instance.health <= 0)
            Death();
        if (IsDead && Input.GetKeyDown(KeyCode.Return))
            RestartGame();
    }

    private void Death()
    {
        IsDead = true;
        IsFirstGame = false;
        StopGameTimer();
        gameOverCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}