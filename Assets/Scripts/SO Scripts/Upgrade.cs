// Code by Jaxon Lee
//
// Modular stat upgrades for some or all of the buildings

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade", order = 0)]
public class Upgrade : ScriptableObject
{
    public float multiplier;

    // Leave this empty to include all
    public List<Building> buildingsToApplyTo = new List<Building>();
    public Sprite image;

    [TextArea]
    public string description;

    [TextArea]
    public string logText;
}
