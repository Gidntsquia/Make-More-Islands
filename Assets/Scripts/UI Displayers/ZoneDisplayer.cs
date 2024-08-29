// Written by Jaxon Lee
//
// A zone is a building zone -- where you can buy things like Dirt Farmers.

using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class ZoneDisplayer : MonoBehaviour
{
    public Resources resources;
    public List<GameObject> allZones = new List<GameObject>();
    public int nextZoneToShow = 0;
    public bool isFirstClick = true;



    // Start is called before the first frame update
    void Start()
    {
        // hide all the zones at first
        foreach (Transform zone in transform)
        {
            allZones.Add(zone.gameObject);

        }

        foreach (GameObject zone in allZones)
        {
            zone.gameObject.SetActive(false);
        }

        // ShowNextBuildingZone();
        // ShowNextBuildingZone();

        resources.ShowAnotheZonerRequest += ShowNextBuildingZone;
    }

    private void Update()
    {
        if (isFirstClick && Input.GetMouseButtonDown(0))
        {
            isFirstClick = false;
            ShowNextBuildingZone();
        }
        else if (nextZoneToShow == 1 && resources.dirt >= 10)
        {
            ShowNextBuildingZone();
        }
        // else if (nextZoneToShow == 3 && resources.dirt >= 10)
        // {
        //     ShowNextBuildingZone();
        // }
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
