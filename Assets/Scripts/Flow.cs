using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Flow  {

    abstract public void Update(float dt);
    abstract public void Clicked(Vector2 loc);

}
