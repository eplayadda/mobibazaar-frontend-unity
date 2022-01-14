using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mb
{
    public class AddToCartElementView : MonoBehaviour
    {
        public AddToCart addToCartElement;
        public Button deleteBtn;
        public Image pic;
        public Text itemName;
        public Text price;

        public void OnDeleteClicked()
        {
            Debug.Log(transform.name + " Item Delleted  :: " + itemName);
        }
    }
}

