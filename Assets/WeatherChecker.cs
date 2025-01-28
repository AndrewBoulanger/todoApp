using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


[Serializable]
public class Condition
{
    public string text;
}
[Serializable]
public class Current
{
    public float temp_c;
    public float feelslike_c;
    public Condition condition;
}
[Serializable]
public class WeatherData
{ 
    public Current current;
}

public class WeatherChecker : MonoBehaviour
{
    private string URL = "https://api.weatherapi.com/v1/current.json?key=fb406733f2e941c4a42204637252201";
    private string loc = "m4j";
    WeatherUIBehaviour UI;

    float waitTime = 900; //15 minutes
    float timer = 900;

    public void setLoc(string location)
    {
        if(location.Length > 2)
        {
            loc = location;
            StartCoroutine(MakeWeatherRequest());
            timer = waitTime;
            PlayerPrefs.SetString("location", loc);
        }
    }

    public string getLoc() { return loc; }
      
    IEnumerator MakeWeatherRequest()
    {
        string json ="no data";
        string fullURL = URL + "&q=" + loc + "&aqi=no";
        
        var req = new UnityWebRequest(fullURL)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };

        yield return req.SendWebRequest();
        if (req.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(req.error);
            yield break;
        }
        else 
        {
            json = req.downloadHandler.text;
            WeatherData data = new WeatherData();
            data = JsonUtility.FromJson<WeatherData>(json);

            if (UI != null)
            {
                UI.UpdateWeather(data);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        UI = gameObject.GetComponent<WeatherUIBehaviour>();

        loc = PlayerPrefs.HasKey("location") ? PlayerPrefs.GetString("location") : loc;

        StartCoroutine(MakeWeatherRequest());
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            StartCoroutine(MakeWeatherRequest());
            timer = waitTime;
        }
    }

}
