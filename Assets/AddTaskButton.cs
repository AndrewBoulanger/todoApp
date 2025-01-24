using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTaskButton : MonoBehaviour
{
    [SerializeField]
    SettingsPanel panel;

    [SerializeField]
    DeleteButton deleteButton;

    public void OpenTaskPanel()
    {
        panel.LerpUp();

        //turn off the delete button if they try to add one too
        if(deleteButton.isDeleteModeOn())
        {
            deleteButton.ToggleDelete();
        }
    }

}
