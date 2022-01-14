using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace mb
{
    public class OrderElementView : MonoBehaviour
    {
        public Image productImg;
        public Button buyBtn;
        public Text productTitle;
        public Text productQuintity;
        public Text productPrice;
        public Text productOldPrice;
        public Text productNewPrice;

        public Order order;
    }
}

