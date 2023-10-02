using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;
using UnityEngine.UIElements;
using UnityEngine.Device;
using Screen = UnityEngine.Screen;

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
    [SerializeField] private float _spawnCooldown = 0.1f;

    [SerializeField] private ComputerMove _computer;
    [SerializeField] private Transform _startPosition;
    public Action OnMinigameComplete;

    [SerializeField] private RectTransform _spawnZone;

    // Start is called before the first frame update
    public void StartMicroGame()
    {
        DeleteNumber();
        RestartGame();
        _computer.transform.position = _startPosition.position;
        GameManager.Instance.IsMinigameOpen = true;
    }

    // Update is called once per frame
    private void Update()
    {
        Score.text = GlobalThings.countNumbers + "/" + _winValue;

        if (GlobalThings.countNumbers > _winValue && GlobalThings.IpGameIsOn)
        {
            Debug.Log("онаедхк");
            OnMinigameComplete?.Invoke();
            GameManager.Instance.IsMinigameOpen = false;
            GlobalThings.IpGameIsOn = false;
            canvas.SetActive(false);
        }
    }

    private void CreateNumber()
    {
        float x = Random.Range(_spawnZone.position.x - _spawnZone.rect.width / 2 * Screen.width / 1920,
            _spawnZone.position.x + _spawnZone.rect.width / 2 * Screen.width / 1920);
        float y = Random.Range(_spawnZone.position.y - _spawnZone.rect.height / 2 * Screen.height / 1080,
             _spawnZone.position.y + _spawnZone.rect.height / 2 * Screen.height / 1080);

        //Debug.Log(_spawnZone.rect.width * Screen.width / 1920);
        //Debug.Log(_spawnZone.rect.height);
        Vector3 spawnPosition = new Vector3(x, y, 0);
        GameObject go = Instantiate(number, spawnPosition, transform.rotation, parent);
        numberList.Add(go);
    }

    private void SpawnNumber()
    {
        minX = -820;
        maxX = 820;
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
        _computer.transform.position = _startPosition.position;
        PanelLose.SetActive(false);
        GlobalThings.IpGameIsOn = true;
        StartCoroutine(ITimer());
    }

    private IEnumerator ITimer()
    {
        while (GlobalThings.IpGameIsOn)
        {
            //SpawnNumber();
            CreateNumber();
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}