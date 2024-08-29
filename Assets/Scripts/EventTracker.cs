using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTracker : MonoBehaviour
{
    private Building building;
    public Resources resources;
    public Button buyButton;
    public bool isFirstTimeBuyable = true;

    // Start is called before the first frame update
    void Start()
    {
        // Get building from the BuildingDisplayer on this GameObject.
        building = gameObject.GetComponent<BuildingDisplayer>().building;

        // Start with buy button disabled.
        buyButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Make this an animation
        if (building.cost <= resources.dirt)
        {
            // We are buyable!
            buyButton.gameObject.SetActive(true);

            if (isFirstTimeBuyable)
            {
                resources.ShowAnotherZone();
                isFirstTimeBuyable = false;
            }
        }
        else
        {
            buyButton.gameObject.SetActive(false);
        }
    }
}
