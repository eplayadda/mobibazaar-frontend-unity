using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mb
{
    public class ProductListView : MonoBehaviour, IView
    {
        public Button backBtn;
        public Button homeBtn;
        public Button orderListBtn;
        public Button cartListBtnHeader;
        public Button cartListBtnFooter;
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


