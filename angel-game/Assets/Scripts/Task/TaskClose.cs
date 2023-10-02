using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskClose : MonoBehaviour
{
    public void CloseMicroGame()
    {
        gameObject.SetActive(false);
        GameManager.Instance.IsMinigameOpen = false;
        GlobalThings.IpGameIsOn = false;

        if (TryGetComponent(out NumberSpawner numberSpawner))
        {
            numberSpawner.DeleteNumber();
        }
    }
}