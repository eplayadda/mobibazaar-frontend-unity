using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mb
{
    public class AddToCartController : BaseController
    {
        [HideInInspector] AddToCartView addToCartView ;

        private void Awake()
        {
            router = gameObject.GetComponentInParent<Router>();
            addToCartView = (AddToCartView)gameObject.GetComponent<IView>();
        }
        private void OnEnable()
        {
            ShowCartItems(MBApplicationData.Instance.selectedCategoryID);
        }
        void ShowCartItems(int parentID = 0, bool addInList = true)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject go = Instantiate(addToCartView.addTCartProtoType) as GameObject;
                AddToCartView mAddToCartView = go.GetComponent<AddToCartView>();
                Button button = go.GetComponent<Button>();
             //   mAddToCartView.category = item;
            //    button.onClick.AddListener(() =>
              //      SetecedCategory(button.gameObject.GetComponent<CategoryViews>())
              //  );

               // go.transform.SetParent(parent, false);
               // categaries.Add(go);
            }

        }
    }
}

