using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductDetailsView :MonoBehaviour, IView
{
    public Button backBtn;
    public Button homeBtn;
    public Button orderListBtn;
    public Button cartListBtnHeader;
    public Button cartListBtnFooter;
    public Image image;
    public Text productName;
    public Text discription;
    public Text rateTxt;
    public Text priceTxt;
    public Text orderPriceTxt;
    public Button addToCartsBtn;
    public GameObject msgPanel;

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
