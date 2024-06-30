using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTracker : MonoBehaviour
{
    public Resources resources;
    public Button createDirtButton;
    public float baseClickValue = 1f;
    public float clickValue;
    public float clickMultiplier;
    public int totalClicks = 0;

    // Start is called before the first frame update
    void Start()
    {
        clickValue = baseClickValue;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // createDirtButton.animationTriggers.pressedTrigger = "true";
            createDirtButton.OnPointerDown(new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current));
            Click();
        }
        else
        {
            createDirtButton.OnPointerUp(new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current));
            createDirtButton.animationTriggers.pressedTrigger = "false";
        }
    }

    public void Click()
    {
        clickValue = baseClickValue + 0.1f * resources.dirtPerSecond;
        resources.AddDirt(clickValue);

        totalClicks += 1;
        if (totalClicks == 100)
        {
            // TODO: Put click avhievement here
            print("100 click achievemnt");
        }
        else if (totalClicks == 500)
        {
            // TODO: Put achievement here 
            print("500 click achievement");
        }
    }
}
