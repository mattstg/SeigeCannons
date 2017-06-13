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

    public void SetTile(Vector2 v2, byte b, bool setTileGraphic = true)
    { //Do not passed vectors that have not been yet parsed, it is not rounded here (GV.CorrectToGridLoc)
        SetTile((int)v2.x, (int)v2.y, b, setTileGraphic);
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

    private void FillCheckAlgo(List<Vector2> toProcess)
    {
        //toProcess are the adjacent pieces to the new placed one
        List<Vector2> closedList  = new List<Vector2>();
        List<Vector2> openList    = new List<Vector2>();
        List<Vector2> invalidList = new List<Vector2>();


    }

    public void SaveBoard(string saveName)
    {
        string path = GV.byteMapSavePath + saveName;
        if (!System.IO.File.Exists(path))
        {
            System.IO.File.Create(path);
        }

        System.IO.TextWriter tw = new System.IO.StreamWriter(path,false);
        for (int y = 0; y < yWidth; y++)
            for (int x = 0; x < xWidth; x++)
            {
                tw.WriteLine(mainBoard[x, y].ToString().PadLeft(3, '0'));
            }
        tw.Close();
    }

    public void LoadBoard(string loadName)
    {
        int x = 0;
        int y = 0;
        foreach (var line in System.IO.File.ReadAllLines(GV.byteMapSavePath + loadName))
        {
            byte b = byte.Parse(line);
            SetTile(x, y, b);
            x++;
            if(x >= xWidth)
            {
                x = 0;
                y++;
            }
        }
    }
}
