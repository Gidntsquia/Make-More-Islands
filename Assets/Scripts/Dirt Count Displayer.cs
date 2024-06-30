using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DirtCountDisplayer : MonoBehaviour
{
    public Resources resources;
    public TMP_Text dirtCounter;

    public void DisplayDirt()
    {
        dirtCounter.text = ((int)resources.dirt).ToString();
    }

    private void Update()
    {
        // Update dirt value
        resources.dirt += resources.dirtPerSecond * Time.deltaTime;
        DisplayDirt();
    }


}
