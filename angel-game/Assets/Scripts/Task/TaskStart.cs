using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskStart : MonoBehaviour
{
    [SerializeField] private GameObject _minigameCanvas;

    [SerializeField] private GameObject _message;

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
    }
}