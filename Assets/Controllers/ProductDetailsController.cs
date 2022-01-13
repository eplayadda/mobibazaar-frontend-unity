using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace mb
{
    public class ProductDetailsController : BaseController
    {
        public string categoryListPath;
        public ProductList productList;
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
            ShowProduct();
        }
        void ShowProduct()
        {
            var pID = MBApplicationData.Instance.selectedProductID;
            var mProduct = productList.products.Where(x => x.id == pID).ToList();
        }
    }

}
