using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    private Character _ownCharacter;
    private Item _conditionItem;

    public Action<float> OnTaskHpChanged;

    [SerializeField] private float _maxTaskHp;
    public float MaxTaskHp => _maxTaskHp;
    private float _currentTaskHp;

    [SerializeField] private float _decreasedHealthPerSecond;

    [SerializeField] private float _second;
    private float _currentSecond;

    public Action OnTaskComplete;
    public Action OnTaskFailed;

    public void Initialize(Item item, Character character)
    {
        _conditionItem = item;
        _ownCharacter = character;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _currentTaskHp = _maxTaskHp;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_currentTaskHp <= 0)
        {
            _currentTaskHp = 0;
            OnTaskHpChanged?.Invoke(0);
            TaskGiver.Instance.DeacreaseTaskCount(_ownCharacter);
            OnTaskFailed?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            if (_currentSecond < 0)
            {
                _currentTaskHp -= _decreasedHealthPerSecond;

                _currentSecond = _second;
                OnTaskHpChanged?.Invoke(_currentTaskHp / _maxTaskHp);
            }
            else
            {
                _currentSecond -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            if (_conditionItem.TypeItem == item.TypeItem)
            {
                TaskGiver.Instance.DeacreaseTaskCount(_ownCharacter);
                OnTaskComplete?.Invoke();
            }
        }
    }
}