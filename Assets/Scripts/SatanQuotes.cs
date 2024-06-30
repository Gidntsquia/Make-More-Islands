using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;
using System.Linq;


[CreateAssetMenu(fileName = "SatanQuotes", menuName = "ScriptableObjects/SatanQuotes", order = 0)]
public class SatanQuotes : ScriptableObject
{

    [TextArea]
    public List<string> quotes = new List<string>();




}
