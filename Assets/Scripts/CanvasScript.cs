using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public ElectrodeSocketManager socketManager;
    public TextMeshProUGUI feedbackText;
    // Start is called before the first frame update
    void Start()
    {
        feedbackText.text = "Click confirm once every electrode has been placed.";
    }
    public void confirmClicked()
    {
        int sum = 0;
        foreach (int i in socketManager.placedSockets)
        {
            sum += i;
        }
        if (sum < 6)
        {
            feedbackText.text = "";
            if (socketManager.placedSockets[0] == 0) feedbackText.text += "V1 should be located on the right of the sternum and 4th intercostal space, i.e. between 4th and 5th ribs. \n \n";
            if (socketManager.placedSockets[1] == 0) feedbackText.text += "V2 should be located on the left of the sternum and 4th intercostal space, i.e. between 4th and 5th ribs. \n \n";
            if (socketManager.placedSockets[2] == 0) feedbackText.text += "V3 should be located midway between V2 and V4. \n \n";
            if (socketManager.placedSockets[3] == 0) feedbackText.text += "V4 should be located on mid clavicular line and 5th intercostal space, i.e. between 5th and 6th ribs. \n \n";
            if (socketManager.placedSockets[4] == 0) feedbackText.text += "V5 should be located on anterior axillary line and 5th intercostal space, i.e. between 5th and 6th ribs. \n \n";
            if (socketManager.placedSockets[5] == 0) feedbackText.text += "V6 should be located on mid axillary line and 5th intercostal space, i.e. between 5th and 6th ribs. \n \n";
        }
        else
        {
            feedbackText.text = "Every electrode has been placed correctly!";
        }
    }
}
