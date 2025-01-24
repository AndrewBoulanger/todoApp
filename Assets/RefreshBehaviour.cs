using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshBehaviour : MonoBehaviour
{
    double timer = 0;
    double dayTimeInSeconds = 86400;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0 )
        {
            timer = dayTimeInSeconds;
            Refresh();
        }
    }

    void Refresh()
    {
        taskBehaviour[] tasks = GetComponentsInChildren<taskBehaviour>();
        foreach( taskBehaviour task in tasks ) 
        {
            task.RefreshTask();
        }
    }

    public void UpdateTimeToRefresh(DateTime next)
    {
        timer = next.Subtract(System.DateTime.Now).TotalSeconds;
        Debug.Log("the timer will refresh in " + timer + " seconds");
    }
}
