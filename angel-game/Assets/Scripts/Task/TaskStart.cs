using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskStart : MonoBehaviour
{
    [SerializeField] private GameObject[] gamesList;
    [SerializeField] private GameObject popupCanvas;

    private int _randNum;

    private void Start()
    {
        _randNum = Random.Range(0, gamesList.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out Movement player))
        {
            popupCanvas.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out Movement player))
        {
            popupCanvas.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gamesList[_randNum].SetActive(true);
        }
    }
}
