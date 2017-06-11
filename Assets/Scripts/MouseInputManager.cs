using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputManager {

    #region Singleton
    private static MouseInputManager instance;

    private MouseInputManager() { }

    public static MouseInputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MouseInputManager();
            }
            return instance;
        }
    }
    #endregion

    private System.Action<Vector2> mouseClickedFunc;
	
    public void SetMouseAction(System.Action<Vector2> _mouseClickedFunc)
    {
        if (mouseClickedFunc != null)
            Debug.Log("Registering mouse action over existing one");
        mouseClickedFunc = _mouseClickedFunc;
    }

    public void UnregisterMouseAction()
    {
        mouseClickedFunc = null;
    }
	
	public void Update (float dt)
    {
		if(Input.GetMouseButtonDown(0) && mouseClickedFunc != null)
        {
            Vector2 mousePos = GV.CorrectToGridLoc(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            mouseClickedFunc(mousePos);
        }

	}

    
}
