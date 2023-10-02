using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textn;

    // Start is called before the first frame update
    private void Start()
    {
        textn.text = Random.Range(0, 10).ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall" && GlobalThings.IpGameIsOn)
        {
            GlobalThings.countNumbers++;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}