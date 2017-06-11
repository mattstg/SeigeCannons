using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorFlow : Flow
{
    EditorPackage editorPkg;
    bool drawByteModeOn = false;
    int drawByte = 0;

    public override void Initialize()
    {
        MouseInputManager.Instance.SetMouseAction(MouseClicked);
        editorPkg = MonoBehaviour.FindObjectOfType<EditorPackage>();
        editorPkg.editorIC.RegisterInputEnteredFunc(InputFromConsole);
    }

    public override void MouseClicked(Vector2 v2)
    {
        Debug.Log("Mouse was clicked: " + v2);
        if(drawByteModeOn)
        {
            Board.Instance.SetTile(v2, (byte)drawByte);
        }
        //throw new NotImplementedException();
    }

    public override void Terminate()
    {
        //throw new NotImplementedException();
    }

    public override void Update(float dt)
    {
        //throw new NotImplementedException();
    }

    private void InputFromConsole(string _cmdInput, string _numericInput)
    {
        if (_cmdInput == "" || _cmdInput == null || _numericInput == "" || _numericInput == null)
        {
            drawByteModeOn = false;
            return;
        }

        switch(_cmdInput)
        {
            case "b": case "byte":
                drawByte = int.Parse(_numericInput);
                drawByteModeOn = true;
                break;
        }        
    }
}
