using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class NumberSpawner : MonoBehaviour
{
    public GameObject number;
    public Transform parent;
    public GameObject canvas;

    private List<GameObject> numberList = new List<GameObject>();

    public float minX, maxX, minY, maxY;

    [SerializeField] private TextMeshProUGUI Score;
    private TextMeshProUGUI textNumber;
    public GameObject PanelLose;

    [SerializeField] private float _winValue = 50;

    public Action OnMinigameComplete;

    // Start is called before the first frame update
    public void StartMicroGame()
    {
        DeleteNumber();
        RestartGame();
        GameManager.Instance.IsMinigameOpen = true;
    }

    // Update is called once per frame
    private void Update()
    {
        Score.text = GlobalThings.countNumbers + "/" + _winValue;

        if (GlobalThings.countNumbers > _winValue && GlobalThings.IpGameIsOn)
        {
            Debug.Log("�������");
            OnMinigameComplete?.Invoke();
            GameManager.Instance.IsMinigameOpen = false;
            GlobalThings.IpGameIsOn = false;
            canvas.SetActive(false);
        }
    }

    private void SpawnNumber()
    {
        minX = -880;
        maxX = 848;
        minY = -40;
        maxY = 446;
        var wantedx = Random.Range(minX, maxX);
        var wantedy = Random.Range(minY, maxY);
        var position = new Vector3(wantedx + 960, wantedy + 540);
        GameObject go = Instantiate(number, position, transform.rotation, parent);
        numberList.Add(go);
    }

    public void DeleteNumber()
    {
        for (int i = 0; i < numberList.Count; i++)
        {
            Destroy(numberList[i]);
        }
    }

    public void RestartGame()
    {
        GlobalThings.countNumbers = 0;
        PanelLose.SetActive(false);
        GlobalThings.IpGameIsOn = true;
        StartCoroutine(ITimer());
    }

    private IEnumerator ITimer()
    {
        while (GlobalThings.IpGameIsOn)
        {
            Debug.Log("Create number");
            SpawnNumber();
            yield return new WaitForSeconds(0.2f);
        }
    }
}