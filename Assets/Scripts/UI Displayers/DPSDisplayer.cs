using System.Linq;
using TMPro;
using UnityEngine;

public class DPSDisplayer : MonoBehaviour
{
    public Resources resources;
    public TMP_Text dpsTextField;

    public void DisplayDPS()
    {
        float totalDPS = resources.buildings.Values.Sum();
        dpsTextField.text = ((int)totalDPS).ToString() + " dirt / second";
    }

    private void Start()
    {
        resources.DPSUpdated += DisplayDPS;
        DisplayDPS();
    }

    private void OnDestroy()
    {
        resources.DPSUpdated -= DisplayDPS;

    }


}
