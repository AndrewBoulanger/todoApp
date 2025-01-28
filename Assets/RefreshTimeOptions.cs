using System;

using UnityEngine;


public class RefreshTimeOptions : MonoBehaviour
{
    [SerializeField]
    RefreshBehaviour refresher;

    // Start is called before the first frame update
    void Start()
    {
        int val = PlayerPrefs.HasKey("refresh") ? PlayerPrefs.GetInt("refresh") : 6;
        SetRefreshTime(val);
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
        PlayerPrefs.SetInt("refresh", value);
    }
}
