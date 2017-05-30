using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board  {

    #region Singleton
    private static Board instance;

    private Board() { }

    public static Board Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Board();
            }
            return instance;
        }
    }
    #endregion

    int xWidth, yWidth;
    byte[,] mainBoard;
    SpriteRenderer[,] srBoard;

    public void SetupBoard(int _xWidth, int _yWidth)
    {
        xWidth = _xWidth;
        yWidth = _yWidth;

        mainBoard = new byte[xWidth, yWidth];
        srBoard = new SpriteRenderer[xWidth, yWidth];
        GV.spriteGridParent = new GameObject().transform;
        GV.spriteGridParent.name = "spriteGridParent";
        GV.spriteGridParent.position = new Vector3();

        for (int x = 0; x < xWidth; x++)
            for (int y = 0; y < yWidth; y++)
            {
                mainBoard[x, y] = 0;
                srBoard[x, y] = new GameObject().AddComponent<SpriteRenderer>();
                srBoard[x, y].name = "tile[" + x + "," + y + "]";
                srBoard[x, y].transform.position = new Vector3(x * GV.spriteTileSize, y * GV.spriteTileSize, 0);
                srBoard[x, y].transform.SetParent(GV.spriteGridParent);
            }

        GV.spriteList = new List<Sprite>();
        foreach (GV.ByteTile bt in System.Enum.GetValues(typeof(GV.ByteTile))) //In theory should add to list in correct order
        {
            Sprite loadedSprite = Resources.Load<Sprite>("Tiles/" + bt.ToString());
            GV.spriteList.Add(loadedSprite);
        }

        //Now set all of them acording to some level design
        LoadLevel(0);
    }
    

    public void SetTile(int x, int y, byte b, bool setTileGraphic = true)
    {
       mainBoard[x, y] = b;
       if (setTileGraphic)
           srBoard[x, y].sprite = GV.spriteList[b];
    }

    public byte GetTile(int x, int y)
    {
        return mainBoard[x, y];
    }

    private void LoadLevel(int layout)
    {
        switch(layout)
        {
            case 0: default:
                for (int x = 0; x < xWidth; x++)
                    for (int y = 0; y < yWidth; y++)
                        SetTile(x, y, (byte)(Random.Range(0, System.Enum.GetNames(typeof(GV.ByteTile)).Length)));
            break;
        }
    }
}
