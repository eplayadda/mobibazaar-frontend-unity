using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour,IView
{
    public Button loginBtn;
    public Button forgotBtn;
    public Button signUpView;
    public InputField mobileInputField;
    public InputField passwordInputField;

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
