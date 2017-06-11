using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Flow  {

    abstract public void Initialize();
    abstract public void Update(float dt);
    abstract public void MouseClicked(Vector2 v2);
    abstract public void Terminate();
}
