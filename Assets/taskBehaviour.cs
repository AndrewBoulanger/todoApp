using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class taskBehaviour : MonoBehaviour
{
    [SerializeField]
    int index;
    static int indexer;
    bool repeatOnRefresh = true;
    [SerializeField]
    TextMeshProUGUI taskName;
    Toggle toggle;

    static DeleteButton deleteButton;
    bool loadDataExists = false;

    private void Start()
    {
        index = indexer++;
        toggle = GetComponent<Toggle>();
        if(deleteButton == null)
            deleteButton = FindAnyObjectByType<DeleteButton>();

        Load();
        if(!loadDataExists)
            gameObject.SetActive(false);
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

        Save();
    }


    public void RefreshTask()
    {
        if(toggle != null && toggle.isOn)
        {
            toggle.isOn = false;
            Save();
        }
        if (!repeatOnRefresh)
        {
            DeleteSave();
            gameObject.SetActive(false);
        }
    }

    public void OnClicked()
    {
        if(deleteButton != null) 
        {
            if (deleteButton.isDeleteModeOn())
            {
                DeleteSave();
                gameObject.SetActive(false);
            }
            else if(taskName.text != "list item")
                Save();
        }
    }

    void Save()
    {
        string jsn = JsonUtility.ToJson(new TaskSaveData(toggle.isOn, taskName.text, repeatOnRefresh));
        string path = Application.persistentDataPath + "/" + "task" + index + ".json";
        System.IO.File.WriteAllText(path, jsn);
    }

    void DeleteSave()
    {
        string path = Application.persistentDataPath + "/" + "task" + index + ".json";
        if(File.Exists(path))
        {
            File.Delete(path);
        }
    }

    void Load()
    {
        string path = Application.persistentDataPath + "/" + "task" + index + ".json";
        if(System.IO.File.Exists(path))
        {
            string data = System.IO.File.ReadAllText(path);
            TaskSaveData saveData = JsonUtility.FromJson<TaskSaveData>(data);

            toggle.isOn = saveData.isOn;
            taskName.text = saveData.label;
            repeatOnRefresh = saveData.repeat;

            loadDataExists = true;
        }
        else
            loadDataExists = false;
    }
}
