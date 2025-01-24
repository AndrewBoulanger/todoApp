using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class taskBehaviour : MonoBehaviour
{
    bool repeatOnRefresh = true;
    [SerializeField]
    TextMeshProUGUI taskName;
    Toggle toggle;

    static DeleteButton deleteButton;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        if(deleteButton == null)
            deleteButton = FindAnyObjectByType<DeleteButton>();
    }
    public void AddTask(string label, bool repeating)
    {
        if (taskName != null)
        {
            taskName.text = label;
        }
        repeatOnRefresh = repeating;
        gameObject.SetActive(true);
        if (toggle != null)
        {
            toggle.isOn = false;
        }
    }


    public void RefreshTask()
    {
        if (!repeatOnRefresh)
        {
            gameObject.SetActive(false);
        }

        if(toggle != null && toggle.isOn)
        {
            toggle.isOn = false;
        }
    }

    public void OnClicked()
    {
        if(deleteButton != null) 
            {
                if(deleteButton.isDeleteModeOn())
                    gameObject.SetActive(false);
            }
    }
}
