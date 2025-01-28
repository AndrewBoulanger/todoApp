using System;
using UnityEngine;

public class RefreshBehaviour : MonoBehaviour
{
    double dayTimeInSeconds = 86400;
    double timer = 86400;

    public DateTime lastRefresh;

    private void Start()
    {

        Load();
    }

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

    public void Refresh()
    {
        taskBehaviour[] tasks = GetComponentsInChildren<taskBehaviour>();
        foreach( taskBehaviour task in tasks ) 
        {
            task.RefreshTask();
        }
        lastRefresh = DateTime.Now;
        Save();
    }

    public void UpdateTimeToRefresh(DateTime next)
    {
        timer = next.Subtract(System.DateTime.Now).TotalSeconds;
    }

    void Save()
    {
        string jsn = JsonUtility.ToJson(lastRefresh);
        string path = Application.persistentDataPath + "/" + "lastRefresh" + ".json";
        System.IO.File.WriteAllText(path, jsn);
    }

    private void Load()
    {
        string path = Application.persistentDataPath + "/" + "lastRefresh" + ".json";
        if (System.IO.File.Exists(path))
        {
            string data = System.IO.File.ReadAllText(path);
            lastRefresh = JsonUtility.FromJson<DateTime>(data);

            if(DateTime.Now.Subtract(lastRefresh).Seconds > dayTimeInSeconds )
                Refresh();
        }
    }
}
