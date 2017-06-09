using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputConsole : MonoBehaviour {

    public UnityEngine.UI.InputField inputFeild;

    public void InputEntered()
    {
        string currentText = inputFeild.text;
        //do stuff
        Debug.Log("text: " + currentText);
        inputFeild.text = "";
    }
}
