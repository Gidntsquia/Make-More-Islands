using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SatanQuotes", menuName = "ScriptableObjects/SatanQuotes", order = 0)]
public class SatanQuotes : ScriptableObject
{
    [TextArea]
    public List<string> quotes = new List<string>();
}
