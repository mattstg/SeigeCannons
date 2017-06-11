using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildFlow : Flow {

    public override void MouseClicked(Vector2 v2)
    {
        Debug.Log("clicked at");
    }

    public override void Initialize()
    {
        
    }

    public override void Update(float dt)
    {

    }

    private void PlacePiece()
    {

    }

    private Transform CreatePhysicalPiece(bool[,] piece, byte b)
    {
        Transform toRet = new GameObject().transform;
        toRet.name = "piece";
        for(int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
            {
                if(piece[x,y])
                {
                    SpriteRenderer sr = new GameObject().AddComponent<SpriteRenderer>();

                }
            }
        return toRet;
    }

    private bool[,] GetNextPiece()
    {
        return new bool[3, 3] 
        {
          {false, true, false }, 
          {false, true, false },
          {false, true, false }
        };
    }

    public override void Terminate()
    {
        //throw new NotImplementedException();
    }
}
