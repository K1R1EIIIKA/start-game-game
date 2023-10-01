using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBug : MonoBehaviour
{
    public GameObject url;
   
    public float speed=500;
    public void OnMouseDown()
    {
        Global.count++;
        Destroy(gameObject);

    }
    void Start()
    {
        url = GameObject.Find("/Canvas/Panel/Url");
       

    }
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, url.transform.position, speed * Time.fixedDeltaTime);
    }
     void Update() {
        Vector3 Look = transform.InverseTransformPoint(url.transform.position);
        float angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, angle);
        //for ( int i=0; i< 5; i++) {
        //    angle = angle + 5 * Time.deltaTime;
        //    transform.Rotate(0, 0, angle);
        //}
        //for ( int i=0; i< 5; i++)
        //{
        //    angle = angle - 5 * Time.deltaTime;
        //    transform.Rotate(0, 0, angle);
        //}
    }
 

}
