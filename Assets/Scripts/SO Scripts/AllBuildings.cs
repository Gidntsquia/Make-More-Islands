// Written by Jaxon Lee

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AllBuildings", menuName = "ScriptableObjects/AllBuildings", order = 0)]
public class AllBuildings : ScriptableObject
{
    public Resources resources;
    public List<Building> allBuildings;
    public Action<string> upgradeApplied;

    public void ApplyUprade(Upgrade upgrade, string logText)
    {
        foreach (Building building in allBuildings)
        {
            // If no buildings selected, apply to all
            if (
                upgrade.buildingsToApplyTo.Count == 0
                || upgrade.buildingsToApplyTo.Contains(building)
            )
            {
                building.StackDPSMultipler(upgrade.multiplier);
            }
        }

        upgradeApplied?.Invoke(logText);
    }

    private void OnEnable()
    {
        allBuildings = resources.buildings.Keys.ToList();
    }
}
