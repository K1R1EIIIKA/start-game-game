using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskStart : MonoBehaviour
{
    [SerializeField] private GameObject _minigameCanvas;

    [SerializeField] private GameObject _message;

    [SerializeField] private Item _reward;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movement movement))
        {
            _message.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Movement movement))
        {
            if (Input.GetKeyDown(KeyCode.E) && !GameManager.Instance.IsMinigameOpen)
            {
                _message.SetActive(false);
                _minigameCanvas.SetActive(true);
                if (_minigameCanvas.TryGetComponent(out NumberSpawner numberSpawner))
                {
                    numberSpawner.StartMicroGame();
                    numberSpawner.OnMinigameComplete += MicrogameComplete;
                }
                if (_minigameCanvas.TryGetComponent(out BugSpawnMove bugSpawnMove))
                {
                    bugSpawnMove.StartMicroGame();
                    bugSpawnMove.OnMinigameComplete += MicrogameComplete;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Movement movement))
        {
            _message.SetActive(false);
        }
        if (_minigameCanvas.TryGetComponent(out NumberSpawner numberSpawner))
        {
            numberSpawner.OnMinigameComplete -= MicrogameComplete;
        }
        if (_minigameCanvas.TryGetComponent(out BugSpawnMove bugSpawnMove))
        {
            bugSpawnMove.OnMinigameComplete -= MicrogameComplete;
        }
    }

    public void MicrogameComplete()
    {
        Item reward = Instantiate(_reward, transform.position, Quaternion.identity);
        reward.IsReference = false;
    }
}