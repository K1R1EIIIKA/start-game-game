using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionUrl : MonoBehaviour
{
    public GameObject PanelLose;
    public GameObject bugLast;
    // Start is called before the first frame update
    void Start()
    {
        
        PanelLose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bug")
        {
            PanelLose.SetActive(true); 
            Destroy(col.gameObject);
            GlobalThings.BugGameisOn = false;
        }
    }
    //public void RestartLevel()
    //{
    //    GlobalThings.countBugs = 0;
    //    PanelLose.SetActive(false);
    //    Time.timeScale = 1;
    //}
}
