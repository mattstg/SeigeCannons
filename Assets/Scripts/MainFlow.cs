using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFlow : MonoBehaviour {
    public int XWidth, YWidth;
    BuildFlow buildFlow;
	// Use this for initialization
	void Start ()
    {
        Board.Instance.SetupBoard(XWidth, YWidth);
        buildFlow = new BuildFlow();
	}

    public void Update()
    {
        buildFlow.Update(Time.deltaTime);
    }
	
}
