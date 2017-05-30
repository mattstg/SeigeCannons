using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV  {

    public enum ByteTile { Ground  = 0, Water = 1 }
    public static Transform spriteGridParent; //Is created and filled by Board.cs
    public static float spriteTileSize = 1; //100pixels

    public static List<Sprite> spriteList;

}
