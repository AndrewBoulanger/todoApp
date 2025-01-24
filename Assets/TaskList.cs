using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    taskBehaviour[] tasks;
    // Start is called before the first frame update
    void Start()
    {
        tasks = GetComponentsInChildren<taskBehaviour>(true);
    }

    public void TryToAddTask(string label, bool repeating)
    {
        foreach (var task in tasks)
        {
            if (task.gameObject.activeSelf == false)
            {
                task.gameObject.SetActive(true);
                task.AddTask(label, repeating);
                break;
            }
        }
    }
}
