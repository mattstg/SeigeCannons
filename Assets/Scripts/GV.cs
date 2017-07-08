using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV  {

	public enum ByteTile { Ground  = 0, Water = 1, Wall = 2 }
    public static Transform spriteGridParent; //Is created and filled by Board.cs
    public static float spriteTileSize = 1; //100pixels

    public static List<Sprite> spriteList;


    public static Vector2 CorrectToGridLoc(Vector2 v2)
    {
        return new Vector2(Mathf.RoundToInt(v2.x), Mathf.RoundToInt(v2.y));
    }
}
