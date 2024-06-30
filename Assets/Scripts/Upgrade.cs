using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade", order = 0)]
public class Upgrade : ScriptableObject
{

    public float multiplier;
    public List<Building> buildingsToApplyTo = new List<Building>();

    [TextArea]
    public string logText;

}
