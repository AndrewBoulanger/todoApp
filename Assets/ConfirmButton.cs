using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textbox;
    [SerializeField]
    Toggle repeatedToggle;

    [SerializeField]
    SettingsPanel panel;

    [SerializeField]
    TaskList tasks;

    public void TryToAddTask()
    {
        if(panel.LerpDown())
        {
            tasks.TryToAddTask(textbox.text, repeatedToggle.isOn);
            textbox.text = "";
            repeatedToggle.isOn = false; 
        }
    }

}
