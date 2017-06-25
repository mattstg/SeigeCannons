using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Building {

    public Vector2 gridLoc; //Top left of the building
    protected bool[,] healthArray; //If true, healthy, is false, unhealthy(destroyed)
    bool destroyed = false;

    public virtual void UpdateBuilding(float dt) { }

    public virtual void TakeDamage(Vector2 _gridLoc)
    {
        Vector2 spotHit = _gridLoc - gridLoc;
        if(healthArray.GetLength(0) >= spotHit.x || healthArray.GetLength(1) >= spotHit.y)
        {
            Debug.LogError(string.Format("Building hit[{0}] ouside of health array range[{1},{2}], from global gridLoc[{3}]", spotHit, healthArray.GetLength(0), healthArray.GetLength(1), _gridLoc));
        }
        else
        {
            healthArray[(int)spotHit.x, (int)spotHit.y] = false;
            if (CheckIsDestroyed())
                BuildingDestroyed();
        }
    }
    
    protected virtual void BuildingDestroyed()
    {
        if(!destroyed)
        { //Doesnt trigger on destroy if already was
            destroyed = true;
            DestroyedCleanup();
        }
    }

    protected virtual void DestroyedCleanup()
    {
        //inherit this and cleaup troops or flags or something, troops maybe lose flags and wander?
    }

    private bool CheckIsDestroyed()
    {//If at least one part is not destroyed, its not destroyed
        for (int x = 0; x < healthArray.GetLength(0); x++)
            for (int y = 0; y < healthArray.GetLength(1); y++)
                if (healthArray[x, y])
                    return false;
        return true;
    }
}
