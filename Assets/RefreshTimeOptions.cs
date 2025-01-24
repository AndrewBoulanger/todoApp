using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RefreshTimeOptions : MonoBehaviour
{
    [SerializeField]
    RefreshBehaviour refresher;

    // Start is called before the first frame update
    void Start()
    {
        SetRefreshTime(6);
    }

    public void SetRefreshTime(int value)
    {
        DateTime next = DateTime.Now;
        if (next.Hour >= value)
        { 
            next = next.Subtract(new TimeSpan(next.Hour - value, next.Minute, next.Second));
            next = next.AddDays(1);
        }
        else
        {
            next = next.AddHours(value - next.Hour);
            next = next.Subtract(new TimeSpan(0, next.Minute, next.Second));
        }

        refresher.UpdateTimeToRefresh(next);
    }
}
