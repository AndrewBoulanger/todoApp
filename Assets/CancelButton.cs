using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textbox;
    [SerializeField]
    Toggle repeatedToggle;

    [SerializeField]
    SettingsPanel panel;

    public void ClosePanel()
    {
        if (panel.LerpDown())
        {
            textbox.text = "";
            repeatedToggle.isOn = false;
        }
    }
}
