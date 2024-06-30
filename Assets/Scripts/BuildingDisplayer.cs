using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDisplayer : MonoBehaviour
{

    public Building building;
    public TMP_Text nameField;
    public TMP_Text costField;
    public TMP_Text countField;
    public TMP_Text dpsField;
    public TMP_Text dpsPerDirtField;
    public Button buyButton;

    // Start is called before the first frame update
    void Start()
    {
        nameField.text = building.buildingName;
        UpdateBuildingData();
        building.myDataHasUpdated += UpdateBuildingData;

        if (buyButton != null)
        {
            buyButton.onClick.AddListener(building.BuyOne);
        }
    }

    void UpdateBuildingData()
    {
        costField.text = ((int)building.cost).ToString() + " dirt";
        countField.text = building.count.ToString();
        dpsField.text = ((int)building.dirtPerSecond).ToString() + " dps";
        dpsPerDirtField.text = roundToHundreths(building.GetDPSPerDirt()).ToString() + " dps / dirt";
    }

    // Rounds a float to the nearest hundreth
    public float roundToHundreths(float varToRound)
    {
        return Mathf.Round(varToRound * 100) / 100f;
    }

    private void OnDestroy()
    {
        building.myDataHasUpdated -= UpdateBuildingData;

    }


}
