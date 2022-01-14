using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mb
{
    public class AddToCartController : BaseController
    {
        [HideInInspector] AddToCartView addToCartView ;
        public List<GameObject> cartItemsGo = new List<GameObject>();
        public Transform parent;

        private void Awake()
        {
            router = gameObject.GetComponentInParent<Router>();
            addToCartView = (AddToCartView)gameObject.GetComponent<IView>();
            OnClickEvents();
        }
        private void OnEnable()
        {
            ShowCartItems(MBApplicationData.Instance.selectedCategoryID);
        }
        void OnClickEvents()
        {
            addToCartView.cartListBtnHeader.onClick.AddListener(() => { OnButtonClicked("cartListBtnHeader"); });
            addToCartView.checkOut.onClick.AddListener(() => { OnButtonClicked("checkOut"); });
            addToCartView.backBtn.onClick.AddListener(() => { OnButtonClicked("backBtn"); });
        }
        void ShowCartItems(int parentID = 0, bool addInList = true)
        {
            var cartItems = MBApplicationData.Instance.addToCartList.products;
            DestoryCartItems();
            foreach (var item in cartItems)
            {
                GameObject go = Instantiate(addToCartView.addTCartProtoType) as GameObject;
                AddToCartElementView mAddToCartView = go.GetComponent<AddToCartElementView>();
                Button button = go.GetComponent<Button>();
                mAddToCartView.name = item.name;
                go.transform.SetParent(parent, false);
                cartItemsGo.Add(go);
            }
           

        }
        void DestoryCartItems()
        {
            foreach (var item in cartItemsGo)
            {
                Destroy(item);
            }
            cartItemsGo.Clear();
        }
    }
}

