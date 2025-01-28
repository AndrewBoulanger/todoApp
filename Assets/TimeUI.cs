using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    TextMeshProUGUI textBox;
    float delay = 1;
    float timer = 0;
    void UpdateUI()
    {
        int hour = System.DateTime.Now.Hour;
        string hourStr = hour.ToString();
        if (hour == 0) hourStr = "12";
        if(hour > 12) hourStr = (hour-12).ToString();

        string meridian = (int)hour > 11 ? "pm" : "am";
        string min = System.DateTime.Now.Minute.ToString();
        if (min.Length == 1) min = "0" + min;

        if (textBox != null)
        {
            textBox.text = hourStr + ":" + min + " " + meridian;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = delay;
                UpdateUI();
        }
    }
}
