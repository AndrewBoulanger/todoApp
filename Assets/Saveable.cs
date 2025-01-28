
[System.Serializable]
public struct TaskSaveData
{ 
    public bool isOn;
    public string label;
    public bool repeat;

    public TaskSaveData(bool isOn, string label, bool repeat)
    {
        this.isOn = isOn;
        this.label = label;
        this.repeat = repeat;
    }
}


