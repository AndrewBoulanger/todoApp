using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    RectTransform rec;
    float targetY;
    [SerializeField]
    float waitTime = 1;

    private void Start()
    {
        rec = GetComponent<RectTransform>();
        targetY = -rec.position.y;
    }

    public bool LerpUp()
    {
        if(rec.position.y != -targetY)
            return false;
        StartCoroutine("Lerp", targetY);
            return true;
    }

    public bool LerpDown()
    {
        if (rec.position.y != targetY)
            return false;
        StartCoroutine("Lerp",- targetY);
            return true;
    }

    IEnumerator Lerp(float targetY)
    {
        float startY = rec.position.y;
        float elapsedTime = 0;
        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            float newY = Mathf.SmoothStep(startY, targetY, elapsedTime/waitTime);
            rec.position = new Vector3(rec.position.x, newY);

            yield return null;
        }
        elapsedTime = 0;
        rec.position = new Vector3(rec.position.x, targetY);
        yield return null;
    }
}
