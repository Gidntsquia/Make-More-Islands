using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "Cronie", menuName = "ScriptableObjects/Cronie", order = 0)]
public class Cronie : ScriptableObject
{
    public string cronieName;
    public int count;
    [TextArea]
    public string quote;
    public Sprite image;

    // Need to check when player has more islands than me


}
