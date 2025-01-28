using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    bool deleteMode = false;
    public bool isDeleteModeOn() { return deleteMode; }

    [SerializeField]
    Image image;

    public void ToggleDelete()
    {
        deleteMode = !deleteMode;
        image.color = (deleteMode ? Color.red : Color.black);

    }
}
