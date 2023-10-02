using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMove : MonoBehaviour
{
    public GameObject PanelLose;
    public int speed = 10;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Number")
        {
            PanelLose.SetActive(true);
            GlobalThings.IpGameIsOn = false;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GlobalThings.IpGameIsOn)
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}