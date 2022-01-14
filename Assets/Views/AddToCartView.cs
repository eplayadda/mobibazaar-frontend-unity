using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace mb
{
    public class AddToCartView : MonoBehaviour, IView
    {
        public Button checkOut;
        public Button cartListBtnHeader;
        public Button backBtn;
        public Text totalAmount;
        public GameObject addTCartProtoType;
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
}

