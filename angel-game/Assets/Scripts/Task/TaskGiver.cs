using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskGiver : MonoBehaviour
{
    [SerializeField] private float _minCooldowm;
    [SerializeField] private float _maxCooldowm;

    private float _currentCooldown;

    public static TaskGiver Instance { get; private set; }
    public Action<Character, Item> OnTaskCreate;

    [SerializeField] private List<Character> _characters;

    private List<Character> _stupidGuys = new List<Character>();
    [SerializeField] private List<Item> _items;

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
        if (_maxTaskCount > _characters.Count)
        {
            _maxTaskCount = _characters.Count;
        }
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
        List<Character> nonStupid = new List<Character>();
        foreach (var character in _characters)
        {
            if (!_stupidGuys.Contains(character))
            {
                nonStupid.Add(character);
            }
        }
        int index = Random.Range(0, nonStupid.Count);
        Character badGuy = nonStupid[index];

        _stupidGuys.Add(badGuy);
        return badGuy;
    }

    private Item GetRandomItem()
    {
        int seed = Environment.TickCount;
        ThreadLocal<System.Random> randomWrapper = new ThreadLocal<System.Random>(() =>
            new System.Random(Interlocked.Increment(ref seed))
        );
        print(randomWrapper.Value);
        // index %= _items.Count;
       // int index = 0;
        int index = Random.Range(0,_items.Count) ;
        return _items[index];
    }

    public void DeacreaseTaskCount(Character character)
    {
        _stupidGuys.Remove(character);
        _taskCount--;
    }
}