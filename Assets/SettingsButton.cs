using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    bool settingsActive = false;
    [SerializeField]
    SettingsPanel panel;

    [SerializeField]
    Sprite settingsIcon;
    [SerializeField]
    Sprite backIcon;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void TryToggleSettings()
    {
        bool result = false;
        if (settingsActive)
        {
            result = panel.LerpDown();
            if (result)
            {
                settingsActive = false;
                image.sprite = settingsIcon;
            }
            Debug.Log(result);
        }
        else
        {
            result = panel.LerpUp();
            if (result)
            {
                settingsActive = true;
                image.sprite = backIcon;
            }
        }
    }
}
