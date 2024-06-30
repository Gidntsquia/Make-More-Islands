using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTracker : MonoBehaviour
{
    public Building building;
    public Resources resources;

    public Button buyButton;

    // Start is called before the first frame update
    void Start()
    {
        buyButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        // TODO: Make this an animation
        if (building.cost > resources.dirt)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
        }
    }
}
