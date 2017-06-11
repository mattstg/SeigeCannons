using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFlow : MonoBehaviour {

    enum Flows {Editor, Build}

    public int XWidth, YWidth;
    BuildFlow buildFlow;
    Flow activeFlow;
	// Use this for initialization
	void Start ()
    {
        Board.Instance.SetupBoard(XWidth, YWidth);
        SwitchFlow(Flows.Editor);
        
	}

    public void Update()
    {
        float dt = Time.deltaTime;
        MouseInputManager.Instance.Update(dt);
        activeFlow.Update(dt);
        
    }

    private void SwitchFlow(Flows newFlow)
    {
        if (activeFlow != null)
            activeFlow.Terminate();

        switch (newFlow)
        {
            case Flows.Build:
                activeFlow = new BuildFlow();
                break;
            case Flows.Editor:
                activeFlow = new EditorFlow();
                break;
        }
        activeFlow.Initialize();
    }
	
}
