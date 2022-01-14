using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HomeView : MonoBehaviour,IView
{
    public Button logOutBtn;
    public Text logOutTxt;
    public Button menuBtn;
    public Button homeBtn;
    public Button orderListBtn;
    public Button cartListBtnHeader;
    public Button cartListBtnFooter;


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
