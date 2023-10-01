using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProgressBarLogic : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 2;
    [SerializeField] private float rotateAcceleration = 1.005f;
    
    
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + rotateSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            rotateSpeed *= rotateAcceleration;

        if (rotateSpeed >= 30)
            rotateSpeed = 0;
    }
}
