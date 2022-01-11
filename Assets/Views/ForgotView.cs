using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForgotView : MonoBehaviour,IView
{
    void Start()
    {
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public string GameObjectName()
    {
        return transform.name;
    }
}
