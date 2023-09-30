using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    [SerializeField] private Image _taskHP;
    [SerializeField] private Image _characterImage;
    [SerializeField] private Image _necessaryItemImage;
    // Start is called before the first frame update

    public void Initialize(Sprite character, Sprite item, float taskHP, Task sugarDaddy)
    {
        _characterImage.sprite = character;
        _necessaryItemImage.sprite = item;
        _taskHP.fillAmount = taskHP;

        sugarDaddy.OnTaskHpChanged += SetCurrentHP;
        sugarDaddy.OnTaskFailed += (() =>
        {
            Destroy(gameObject);
        });
    }

    private void SetCurrentHP(float hp)
    {
        _taskHP.fillAmount = hp;
    }
}