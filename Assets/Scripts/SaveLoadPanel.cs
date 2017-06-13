using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadPanel : MonoBehaviour {

    public InputField saveLoadInputFeild;

    public void SaveButtonPressed()
    {
        string sltext = saveLoadInputFeild.text;
        Board.Instance.SaveBoard(sltext);
    }

    public void LoadButtonPressed()
    {
        string sltext = saveLoadInputFeild.text;
        Board.Instance.LoadBoard(sltext);
    }
}
