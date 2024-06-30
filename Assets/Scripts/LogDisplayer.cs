using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogDisplayer : MonoBehaviour
{
    public AllBuildings allBuildings;
    public TMP_Text logField;

    // Start is called before the first frame update
    void Start()
    {
        logField.text = "";
        allBuildings.upgradeApplied += AddToLogField;

    }

    public void AddToLogField(string stringToAdd)
    {
        logField.text += stringToAdd + "\n\n";
    }

    private void OnDestroy()
    {
        allBuildings.upgradeApplied -= AddToLogField;
    }


}
