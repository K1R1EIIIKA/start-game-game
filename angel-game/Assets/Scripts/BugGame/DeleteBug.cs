using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBug : MonoBehaviour
{
    public GameObject url;

    public float speed = 500;

    public void OnMouseDown()
    {
        if (GlobalThings.BugGameisOn)
        {
            GlobalThings.ÑountBugs++;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        url = GameObject.Find("/BugGame/Microgame/URL");
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, url.transform.position, speed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        Vector3 Look = transform.InverseTransformPoint(url.transform.position);
        float angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, angle);
    }
}