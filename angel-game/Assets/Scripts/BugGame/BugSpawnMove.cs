using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class BugSpawnMove : MonoBehaviour
{
    public GameObject url;
    public GameObject bug;
    public GameObject canvas;
    public Transform parent;
    public GameObject PanelLose;

    public float minX, maxX, minY, maxY;

    private List<GameObject> bugList = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI Score;

    [SerializeField] private float _winCondition;

    public Action OnMinigameComplete;

    public void StartMicroGame()
    {
        DeleteBugs();
        RestartGame();
        GameManager.Instance.IsMinigameOpen = true;
    }

    public void RestartGame()
    {
        GlobalThings.—ountBugs = 0;
        PanelLose.SetActive(false);
        GlobalThings.BugGameisOn = true;
        StartCoroutine(ITimer());
    }

    private void FirstPos()
    {
        minX = -880;
        maxX = -300;
        minY = -465;
        maxY = 425;
        var wantedx = Random.Range(minX, maxX);
        var wantedy = Random.Range(minY, maxY);
        var position = new Vector3(wantedx + 960, wantedy + 540);
        GameObject go = Instantiate(bug, position, transform.rotation, parent);
        bugList.Add(go);
    }

    private void SecondPos()
    {
        minX = 365;
        maxX = 856;
        minY = -465;
        maxY = 425;
        var wantedx = Random.Range(minX, maxX);
        var wantedy = Random.Range(minY, maxY);
        var position = new Vector3(wantedx + 960, wantedy + 540);
        var go = Instantiate(bug, position, transform.rotation, parent);
        bugList.Add(go);
    }

    public void DeleteBugs()
    {
        for (int i = 0; i < bugList.Count; i++)
        {
            Destroy(bugList[i]);
        }
    }

    private void Update()
    {
        Score.text = GlobalThings.—ountBugs + "/" + _winCondition;

        if (GlobalThings.—ountBugs >= _winCondition)
        {
            Debug.Log("œŒ¡≈ƒ»À");
            OnMinigameComplete?.Invoke();
            GameManager.Instance.IsMinigameOpen = false;
            GlobalThings.BugGameisOn = false;
            canvas.SetActive(false);
        }
    }

    private IEnumerator ITimer()
    {
        while (GlobalThings.BugGameisOn)
        {
            yield return new WaitForSeconds(1f);
            FirstPos();
            yield return new WaitForSeconds(1f);
            SecondPos();
        }
    }
}