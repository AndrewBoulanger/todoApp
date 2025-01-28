using TMPro;
using UnityEngine;

enum Months
{
    January = 1, February, March, April, May, June, July, August, September, October, November, December
}
public class DateCheck : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dateText;

    float timeDelay = 2;
    float timer = 0;

    private void UpdateDay()
    {
        string dayOfWeek = System.DateTime.Now.DayOfWeek.ToString();
        string month = ((Months)System.DateTime.Now.Month).ToString();
        string day = System.DateTime.Now.Day.ToString();
        string year = System.DateTime.Now.Year.ToString();

        if(dateText != null )
            dateText.text = dayOfWeek + " " + month + " " + day + ", " + year;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            UpdateDay();
            timer = timeDelay;
        }
    }
}
