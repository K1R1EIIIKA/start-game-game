using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCreator : MonoBehaviour
{
    [SerializeField] private Task _taskTemplate;
    [SerializeField] private TaskUI _taskOnScreen;
    [SerializeField] private TaskUI _taskUpperCharacter;

    [SerializeField] private Transform _TaskUIContainer;

    // Start is called before the first frame update
    private void Start()
    {
        TaskGiver.Instance.OnTaskCreate += CreateTask;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void CreateTask(Character character, Item item)
    {
        Task task = Instantiate(_taskTemplate, character.ItemContainerPosition.position, Quaternion.identity);
        task.Initialize(item, character);

        TaskUI taskOnScreen = Instantiate(_taskOnScreen);
        taskOnScreen.Initialize(character.OwnIcon, item.OwnIcon, task.MaxTaskHp, task);
        taskOnScreen.transform.SetParent(_TaskUIContainer);

        TaskUI taskUpperCharacter = Instantiate(_taskUpperCharacter, character.UIPositon.position, Quaternion.identity);
        taskUpperCharacter.Initialize(character.OwnIcon, item.OwnIcon, task.MaxTaskHp, task);
    }
}