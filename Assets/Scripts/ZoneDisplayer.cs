// Written by Jaxon Lee
//
// A zone is a building zone -- where you can buy things like Dirt Farmers.

using System.Collections.Generic;
using UnityEngine;

public class ZoneDisplayer : MonoBehaviour
{
    public Resources resources;
    public List<GameObject> allZones = new List<GameObject>();
    public int nextZoneToShow = 0;


    // Start is called before the first frame update
    void Start()
    {
        // hide all the zones at first
        foreach (Transform zone in transform)
        {
            allZones.Add(zone.gameObject);
            zone.gameObject.SetActive(false);
        }


        // Ensure there are always two being shown.
        ShowNextBuildingZone();
        ShowNextBuildingZone();

        resources.ShowAnotheZonerRequest += ShowNextBuildingZone;
    }



    public void ShowNextBuildingZone()
    {
        if (nextZoneToShow < allZones.Count)
        {
            allZones[nextZoneToShow].SetActive(true);
            nextZoneToShow += 1;
        }
        else
        {
            print("ZoneDisplayer: No more zones to show");
        }
    }

    private void OnDestroy()
    {
        resources.ShowAnotheZonerRequest -= ShowNextBuildingZone;

    }
}
