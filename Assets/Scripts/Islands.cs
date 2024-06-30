using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Islands", menuName = "ScriptableObjects/Islands", order = 0)]
public class Islands : ScriptableObject
{
    public float baseCost = 10f;
    public float costIncreaseMultiplier = 1.1f;

    public int count;
    public float cost;

    public Action myDataHasUpdated;
    public Resources resources;

    private void OnEnable()
    {
        count = 0;
        cost = baseCost;
    }

    [Button]
    public void BuyOne()
    {
        resources.dirt -= cost;
        count += 1;
        cost = cost * costIncreaseMultiplier;
        myDataHasUpdated?.Invoke();
    }








}
