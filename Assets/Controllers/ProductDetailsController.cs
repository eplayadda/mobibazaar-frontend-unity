using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace mb
{
    public class ProductDetailsController : BaseController
    {
        [HideInInspector] ProductDetailsView productDetailsView;

        public string categoryListPath;
        public ProductList productList;
        private void Awake()
        {
            router = gameObject.GetComponentInParent<Router>();
            productDetailsView = (ProductDetailsView)gameObject.GetComponent<IView>();

            OnClickEvents();

        }
        void OnEnable()
        {
            SetProductByID();
        }
        void OnClickEvents()
        {
            productDetailsView.addToCartsBtn.onClick.AddListener(() => { OnProductAdded(); });
        }
        void OnProductAdded()
        {
            productDetailsView.msgPanel.SetActive(true);
            Invoke("DisableMsg", 2f);
        }

        void DisableMsg()
        {
            productDetailsView.msgPanel.SetActive(false);
            router.ActivateScreen("Products_List");
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
