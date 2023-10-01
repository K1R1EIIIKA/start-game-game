using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BugSpawnMove : MonoBehaviour
{
    public GameObject url;
    public GameObject bug;
    public GameObject canvas;
    public Transform parent;

    public float minx, maxx, miny, maxy;
   
    [SerializeField] private TextMeshProUGUI Score;
    private bool GameIsOn = true;

    private void FirstPos()
    {
       
        minx = -880;
        maxx = -350;
        miny = -465;
        maxy = 425;
        var wantedx = Random.Range(minx, maxx);
        var wantedy = Random.Range(miny, maxy);
        var position = new Vector3(wantedx + 960, wantedy + 540);
        GameObject go = Instantiate(bug, position, transform.rotation,parent);
    }
    private void SecondPos()
    {
        minx = 365;
        maxx = 856;
        miny = -465;
        maxy = 425;
        var wantedx = Random.Range(minx, maxx);
        var wantedy = Random.Range(miny, maxy);
        var position = new Vector3(wantedx+960, wantedy+540);
        var go = Instantiate(bug, position, transform.rotation,parent);
       
    }

    void Start()
    {
        
        StartCoroutine(ITimer());
        
    }

    void Update()
    {
        Score.text = GlobalThings.countBugs.ToString() + "/20";

        if (GlobalThings.countBugs > 20)
        {
            GameIsOn = false; GlobalThings.cookie++;
            canvas.SetActive(false);
        }
        else
        {
            GameIsOn = true;
        }
    }

    IEnumerator ITimer()
    {
        while (GameIsOn)
        {
            yield return new WaitForSeconds(1f);
            FirstPos();
            yield return new WaitForSeconds(1f);
            SecondPos();
        }
    }
}