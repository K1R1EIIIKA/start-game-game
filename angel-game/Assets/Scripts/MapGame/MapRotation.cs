using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProgressBarLogic : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 2;
    [SerializeField] private float rotateAcceleration = 1.005f;

    [SerializeField] private float _targetRotationSpeedValue;
    [SerializeField] private float _startRotationSpeed = 1;

    [SerializeField] private Transform _rotatedObjet;
    public Action OnMinigameComplete;

    public void StartMicroGame()
    {
        GameManager.Instance.IsMinigameOpen = true;
        _rotatedObjet.rotation = Quaternion.identity;
        rotateSpeed = _startRotationSpeed;
    }

    public void StopMicroGame()
    {
        GameManager.Instance.IsMinigameOpen = false;
    }

    private void Update()
    {
        _rotatedObjet.rotation = Quaternion.Euler(0, _rotatedObjet.rotation.eulerAngles.y + rotateSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            rotateSpeed += rotateAcceleration;

        if (rotateSpeed >= _targetRotationSpeedValue)
        {
            rotateSpeed = _targetRotationSpeedValue;
            OnMinigameComplete?.Invoke();
            GameManager.Instance.IsMinigameOpen = false;
            gameObject.SetActive(false);
        }
        else if (rotateSpeed > 1)
        {
            rotateSpeed -= Time.deltaTime;
        }
    }
}