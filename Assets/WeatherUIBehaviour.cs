using TMPro;
using UnityEngine;

public class WeatherUIBehaviour : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI temp_label, feelslikeLabel, condition_label;

    public void UpdateWeather(WeatherData data)
    {
        if (temp_label != null && feelslikeLabel != null && condition_label != null)
        {
            temp_label.text = data.current.temp_c.ToString();
            feelslikeLabel.text = data.current.feelslike_c.ToString();
            condition_label.text = data.current.condition.text;
        }

    }
}
