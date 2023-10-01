using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerMove : MonoBehaviour
{
    public GameObject PanelLose;
    public int speed=10;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Number")
        {
            Time.timeScale = 0;
            GlobalThings.countNumbers = 0;
            PanelLose.SetActive(true);
            GlobalThings.ipGameisOn = false;

        }
    }
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*speed * Time.fixedDeltaTime, 0 ,0);
    }
}
