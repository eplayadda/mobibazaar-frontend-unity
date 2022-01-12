using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace mb
{
    public class ProductListController : MonoBehaviour
    {
        public string categoryListPath;
        public ProductList productList;
        public GameObject product_ProtoType;
        public Transform parent;
        public List<GameObject> products = new List<GameObject>();
        Router router;
        private void Awake()
        {
            router = gameObject.GetComponentInParent<Router>();

        }
        void OnEnable()
        {
            SetProductByID();
        }
        void SetProductByID()
        {
            var response = Resources.Load<TextAsset>(categoryListPath);
            var str = "{\"products\":" + response.text + "}";
            productList = JsonUtility.FromJson<ProductList>(str);
            CreateProduct();
        }

        void CreateProduct()
        {
            var pID = MBApplicationData.Instance.selectedCategoryID;
            var subCategories = productList.products.Where(x => x.categoryId == pID).ToList();
            foreach (var item in subCategories)
            {
                GameObject go = Instantiate(product_ProtoType) as GameObject;
                var mProductViews = go.GetComponent<ProductViews>();
                Button button = go.GetComponent<Button>();
                mProductViews.product = item;
                button.onClick.AddListener(() =>
                    SetecedCategory(button.gameObject.GetComponent<ProductViews>())
                );
                mProductViews.buyBtn.onClick.AddListener(() =>
                   SetecedCategory(button.gameObject.GetComponent<ProductViews>())
               );
                go.transform.SetParent(parent, false);
                products.Add(go);
            }

        }

        void SetecedCategory(ProductViews productViews)
        {
            //  loadingPanel.OnActivation();
            Debug.Log("Selected Category ::" + productViews.product.id);
            MBApplicationData.Instance.selectedProductID = productViews.product.id;
            router.ActivateScreen("Products_Details");

        }
    }
}

