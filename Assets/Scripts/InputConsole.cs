using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputConsole : MonoBehaviour {

    public UnityEngine.UI.InputField cmdInputFeild;
    public UnityEngine.UI.InputField numericInputFeild;
    private System.Action<string,string> inputEnterFunc;

    public void RegisterInputEnteredFunc(System.Action<string,string> _toRegister)
    {
        inputEnterFunc = _toRegister;
    }

    public void InputEntered()
    {
        if (inputEnterFunc != null)
            inputEnterFunc(cmdInputFeild.text, numericInputFeild.text);
        cmdInputFeild.text = numericInputFeild.text = "";
    }

    
}
