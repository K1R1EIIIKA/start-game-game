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
    public GameObject PanelLose;


    public float minx, maxx, miny, maxy;

    private List<GameObject> numberList = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI Score;

    public void StartMicroGame()
    {
        DeleteBugs();
        RestartGame();
        GameManager.Instance.IsMinigameOpen = true;
    }
    public void RestartGame()
    {
        GlobalThings.countBugs = 0;
        PanelLose.SetActive(false);
        GlobalThings.bugGameisOn = true;
        StartCoroutine(ITimer());
    }
    private void FirstPos()
    {
        minx = -880;
        maxx = -300;
        miny = -465;
        maxy = 425;
        var wantedx = Random.Range(minx, maxx);
        var wantedy = Random.Range(miny, maxy);
        var position = new Vector3(wantedx + 960, wantedy + 540);
        GameObject go = Instantiate(bug, position, transform.rotation, parent);
        numberList.Add(go);
    }

    private void SecondPos()
    {
        minx = 365;
        maxx = 856;
        miny = -465;
        maxy = 425;
        var wantedx = Random.Range(minx, maxx);
        var wantedy = Random.Range(miny, maxy);
        var position = new Vector3(wantedx + 960, wantedy + 540);
        var go = Instantiate(bug, position, transform.rotation, parent);
        numberList.Add(go);
    }

    public void DeleteBugs()
    {
        for (int i = 0; i < numberList.Count; i++)
        {
            Destroy(numberList[i]);
        }
    }
    private void Update()
    {
        Score.text = GlobalThings.countBugs.ToString() + "/20";

        if (GlobalThings.countBugs > 20)
        {
            GlobalThings.bugGameisOn = false;
            canvas.SetActive(false);
        }
       
    }

    private IEnumerator ITimer()
    {
        while (GlobalThings.bugGameisOn)
        {
            yield return new WaitForSeconds(1f);
            FirstPos();
            yield return new WaitForSeconds(1f);
            SecondPos();
        }
    }
}