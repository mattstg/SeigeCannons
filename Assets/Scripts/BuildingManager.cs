using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager
{
    //Each player should have one, easier for online 
    List<Building> playerOwnedbuildings;

    public void UpdateBuildingManager(float dt)
    {
        foreach (Building b in playerOwnedbuildings)
            b.UpdateBuilding(dt);
    }

    public void AddPlayerBuilding(Building toAdd)
    {
        if (!playerOwnedbuildings.Contains(toAdd))
            playerOwnedbuildings.Add(toAdd);
    }

    public void RemovePlayerBuilding(Building toRemove)
    {
        playerOwnedbuildings.Remove(toRemove);
    }

}
