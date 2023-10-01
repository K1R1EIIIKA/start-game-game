using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite _ownIcon;

    [SerializeField] private bool _isReference;
    public Sprite OwnIcon => _ownIcon;
    public Type TypeItem;
    private ItemPorter _porter;

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

    private void OnTriggerEnter(Collider other)
    {
        if (!_isReference)
        {
            if (other.TryGetComponent(out ItemPorter owner))
            {
                owner.TryJumpInBag(this);
                _porter = owner;
            }
        }
    }

    public void CompleteTarget()
    {
        _porter.JumpOutBag(this);
        Destroy(gameObject);
    }
}