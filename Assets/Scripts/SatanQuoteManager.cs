using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SatanQuoteManager : MonoBehaviour
{
    public SatanQuotes satanQuotes;
    public TMP_Text sataQuoteField;
    public float timeToWait = 20f;

    private void Start()
    {
        StartCoroutine("loopThroughQuotes");
    }

    public IEnumerator loopThroughQuotes()
    {
        print("Starign ienumertaor");
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);
            int randIndex = Random.Range(0, satanQuotes.quotes.Count - 1);
            sataQuoteField.text = "\"" + satanQuotes.quotes[randIndex] + "\" -";
            print("change satan quote");
        }
    }

}
