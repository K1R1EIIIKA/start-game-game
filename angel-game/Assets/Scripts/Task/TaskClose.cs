using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskClose : MonoBehaviour
{
    public void CloseGame()
    {
        Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Close();
    }

    private void Close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
