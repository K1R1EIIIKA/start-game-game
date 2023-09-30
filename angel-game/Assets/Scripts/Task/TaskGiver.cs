using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskGiver : MonoBehaviour
{
    [SerializeField] private float _minCooldowm;
    [SerializeField] private float _maxCooldowm;

    private float _currentCooldown;

    public static TaskGiver Instance { get; private set; }
    public Action<Character, Item> OnTaskCreate;

    [SerializeField] private List<Character> _characters = new List<Character>();

    private List<Character> _stupidGuys = new List<Character>();
    [SerializeField] private List<Item> _items = new List<Item>();

    [SerializeField] private int _maxTaskCount = 3;
    private int _taskCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        _currentCooldown = GetRandomCooldowm();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_taskCount < _maxTaskCount)
        {
            if (_currentCooldown < 0)
            {
                _taskCount++;
                OnTaskCreate?.Invoke(GetRandomCharacter(), GetRandomItem());
                _currentCooldown = GetRandomCooldowm();
                Debug.Log(_currentCooldown);
            }
            else
            {
                _currentCooldown -= Time.deltaTime;
            }
        }
    }

    private float GetRandomCooldowm()
    {
        return Random.Range(_minCooldowm, _maxCooldowm);
    }

    private Character GetRandomCharacter()
    {
        Debug.Log(_characters.Count - 1);
        int index = Random.Range(0, _characters.Count - 1);
        Character badGuy = _characters[index];
        while (_stupidGuys.Contains(_characters[index]))
        {
            index = Random.Range(0, _characters.Count - 1);
            badGuy = _characters[index];
        }

        return badGuy;
    }

    private Item GetRandomItem()
    {
        int index = Random.Range(0, _items.Count - 1);
        return _items[index];
    }

    public void DeacreaseTaskCount()
    {
        _taskCount--;
    }
}