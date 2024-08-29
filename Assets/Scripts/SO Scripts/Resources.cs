using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;
using System.Linq;


[CreateAssetMenu(fileName = "Resources", menuName = "ScriptableObjects/Resources", order = 0)]
public class Resources : ScriptableObject
{
    public float dirt = 0;
    public float dirtPerSecond = 0f;

    [SerializedDictionary("Building", "DirtPerSecond")]
    public SerializedDictionary<Building, float> buildings = new SerializedDictionary<Building, float>();
    public event Action DPSUpdated;
    public event Action ShowAnotheZonerRequest;

    public void AddDirt(float dirtToAdd) { dirt += dirtToAdd; }

    [Button]
    public void Add1Dirt() { AddDirt(1); }

    [Button]
    public void UpdateDPS()
    {
        // Update dirt per second from all the buildings, and update the 
        // DPS displayer
        dirtPerSecond = buildings.Values.Sum();
        DPSUpdated?.Invoke();
    }

    [Button]
    public void ShowAnotherZone()
    {
        ShowAnotheZonerRequest?.Invoke();
    }



    // Re-import all buildings on start
    private void OnEnable()
    {
        dirtPerSecond = 0;
        dirt = 1;

#if UNITY_EDITOR

        // Code adapted from StackOverflow answer by Jack Mariani
        // https://stackoverflow.com/questions/56167870/find-all-the-instances-of-a-scriptable-object-and-store-it-in-a-list

        // Remove whatever was in building map before
        buildings.Clear();

        // Find all buildings in Scriptable Objects folder
        string[] assetNames = UnityEditor.AssetDatabase.FindAssets("t:Building", new[] { "Assets/Assets/Scriptable Objects" });

        // Go through each building we found and add it to the building map.
        foreach (string SOName in assetNames)
        {
            // Get path from building name and then get the actual object
            string SOpath = UnityEditor.AssetDatabase.GUIDToAssetPath(SOName);
            Building building = UnityEditor.AssetDatabase.LoadAssetAtPath<Building>(SOpath);

            buildings.Add(building, 0);
        }
#endif
    }




}
