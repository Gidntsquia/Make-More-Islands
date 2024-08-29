using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IslandsDisplayer : MonoBehaviour
{
    public Islands islands;
    public Resources resources;
    public TMP_Text costField;
    public TMP_Text countField;
    public Button buyButton;
    public bool isFirstTimeBuyable = true;


    // Start is called before the first frame update
    void Start()
    {
        UpdateIslandData();
        buyButton.onClick.AddListener(islands.BuyOne);
        buyButton.gameObject.SetActive(false);

        islands.myDataHasUpdated += UpdateIslandData;

    }


    void UpdateIslandData()
    {
        costField.text = ((int)islands.cost).ToString() + " dirt";
        countField.text = "Islands\n" + islands.count.ToString();
    }


    // Update is called once per frame
    void Update()
    {

        // TODO: Make this an animation
        if (islands.cost <= resources.dirt)
        {
            // We are buyable!
            buyButton.gameObject.SetActive(true);

            if (isFirstTimeBuyable)
            {
                // resources.ShowAnotherZone();
                isFirstTimeBuyable = false;
            }

        }
        else
        {
            buyButton.gameObject.SetActive(false);
        }
    }


    private void OnDestroy()
    {
        islands.myDataHasUpdated -= UpdateIslandData;
    }



}
