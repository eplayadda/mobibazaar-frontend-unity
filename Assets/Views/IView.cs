using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView 
{
    void Activate();
    void Deactivate();
    string GameObjectName();
}
