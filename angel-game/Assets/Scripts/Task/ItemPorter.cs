using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPorter : MonoBehaviour
{
    private bool _isBusy;

    [SerializeField] private Transform _itemSpot;
    private Item _currentItem;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (_currentItem != null && _isBusy)
            {
                _isBusy = false;
                _currentItem.CompleteTarget();
            }
        }
    }

    public void TryJumpInBag(Item item)
    {
        if (!_isBusy)
        {
            _currentItem = item;

            _currentItem.transform.position = _itemSpot.position;
            _currentItem.transform.SetParent(_itemSpot);
            _isBusy = true;
        }
    }

    public void JumpOutBag(Item item)
    {
        _isBusy = false;
    }
}