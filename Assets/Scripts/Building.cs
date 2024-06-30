using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Building", order = 0)]
public class Building : ScriptableObject
{
    public static float costIncreaseMultiplier = 1.15f;
    public string buildingName;
    // Track everything internally as floats, but only display as ints.
    public float baseCost;
    public float baseDirtPerSecond;

    public int count;
    public float cost;
    public float dirtPerSecond;
    public float dirtPerSecondMultiplier;
    public Action myDataHasUpdated;



    public Resources resources;

    private void OnEnable()
    {
        count = 0;
        cost = baseCost;
        dirtPerSecond = baseDirtPerSecond;
        dirtPerSecondMultiplier = 1;
    }

    [Button]
    public void BuyOne()
    {
        count += 1;
        cost = cost * costIncreaseMultiplier;
        UpdateDPSContribution();
        myDataHasUpdated?.Invoke();


    }

    public float GetDPSContribution()
    {
        return dirtPerSecond * count;
    }

    public float GetDPSPerDirt()
    {
        // Cover for div by 0 edge case
        return cost != 0 ? dirtPerSecond / cost : Mathf.Infinity;
    }

    public void StackDPSMultipler(float multiplierToStack)
    {
        dirtPerSecondMultiplier *= multiplierToStack;
        UpdateDPSContribution();
    }

    public void UpdateDPSContribution()
    {
        resources.buildings[this] = GetDPSContribution();
        resources.UpdateDPS();

    }




}
