using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite _ownIcon;
    public Sprite OwnIcon => _ownIcon;
    public Type TypeItem;

    public enum Type
    {
        Type1,
        Type2,
        Type3
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}