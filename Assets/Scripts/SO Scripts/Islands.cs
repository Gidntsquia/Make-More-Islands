using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Islands", menuName = "ScriptableObjects/Islands", order = 0)]
public class Islands : ScriptableObject
{
    public float baseCost = 20f;
    public float costIncreaseMultiplier = 1.5f;

    public int count;
    public float cost;

    public Action myDataHasUpdated;
    public Resources resources;
    public bool isFirstPurchase = true;

    private void OnEnable()
    {
        isFirstPurchase = true;
        count = 0;
        cost = baseCost;
    }

    [Button]
    public void BuyOne()
    {
        if (count == 0)
        {
            resources.ShowAnotherZone();
        }
        else if (count == 1)
        {
            resources.ShowAnotherZone();
        }
        else if (count == 2)
        {
            resources.ShowAnotherZone();
        }

        resources.dirt -= cost;

        if (count == 0)
        {
            cost += 10;
        }
        else
        {
            cost = cost * costIncreaseMultiplier;
        }
        count += 1;
        myDataHasUpdated?.Invoke();
    }
}
