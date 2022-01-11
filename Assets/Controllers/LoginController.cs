using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mb.Model;
using Mb.Network;
using mb;

public class LoginController : MonoBehaviour, IBackButton
{
    [HideInInspector] public LoginView loginView;
    Router router;
    LoginResponse loginResponse;
    private void Start()
    {
        router = gameObject.GetComponentInParent<Router>();
        loginView =(LoginView) gameObject.GetComponent<IView>();
        OnClickEvents();
    }

    void OnClickEvents()
    {
        loginView.loginBtn.onClick.AddListener(() => { OnLoginPressed(); });
        loginView.forgotBtn.onClick.AddListener(() => { OnForgotPressed(); });
        loginView.signUpView.onClick.AddListener(() => { OnSignUpPressed(); });
    }

    void OnLoginPressed()
    {
        LoginRequest loginRequest = new LoginRequest();
        loginRequest.mob_number = loginView.mobileInputField.text;
        loginRequest.password = loginView.passwordInputField.text;
        string loginBodyStr = JsonUtility.ToJson(loginRequest);
        MBApplicationData.Instance.AccessToken = "login_done";
        router.ActivateScreen("Home");
        //  NewtonWebRequest.Instance.BeingPostRequest(Constant.baseURL, "", loginBodyStr, LoginCallback);
        Debug.Log("Login pressed");
    }

    void LoginCallback(bool success, string response)
    {
        if (success)
        {
            loginResponse = JsonUtility.FromJson<LoginResponse>(response);
            MbApplicationData.AccessToken = loginResponse.access_token;
            router.ActivateScreen("Home");
        }
        else
        {
        }
    }

    void OnForgotPressed()
    {
        Debug.Log("Forgot pressed");
    }

    void OnSignUpPressed()
    {
        Debug.Log("SignUp pressed");
        router.ActivateScreen("SignUp");

    }
    public void OnBackPressed(string backScreen)
    {
        router.ActivateScreen(backScreen);
    }
}
