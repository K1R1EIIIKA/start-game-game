using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Sprite _ownIcon;
    public Sprite OwnIcon => _ownIcon;
    [SerializeField] private Transform _itemContainerPosition;
    public Transform ItemContainerPosition => _itemContainerPosition;

    [SerializeField] private Transform _UIPositon;
    public Transform UIPositon => _UIPositon;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}