using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMove : MonoBehaviour
{
    public GameObject PanelLose;
    public int speed = 10;

    private float inputDirection;
    private bool isTouchingBorder;
    private BorderPlayerZeone _border;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "Number")
        {
            PanelLose.SetActive(true);
            GlobalThings.IpGameIsOn = false;
        }
        if (collision.TryGetComponent(out BorderPlayerZeone border))
        {
            isTouchingBorder = true;
            _border = border;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BorderPlayerZeone border))
        {
            isTouchingBorder = false;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Update()
    {
        inputDirection = Input.GetAxis("Horizontal");
        if (isTouchingBorder)
        {
            if (_border.IsRight)
            {
                if (inputDirection > 0)
                {
                    inputDirection = 0;
                }
            }
            else
            {
                if (inputDirection < 0)
                {
                    inputDirection = 0;
                }
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GlobalThings.IpGameIsOn)
            transform.position += new Vector3(inputDirection * speed * Time.fixedDeltaTime, 0, 0);
    }
}