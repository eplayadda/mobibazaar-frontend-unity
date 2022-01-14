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
        public Product selectedProduct;
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
            productDetailsView.cartListBtnFooter.onClick.AddListener(() => { OnButtonClicked("cartListBtnFooter"); });
            productDetailsView.cartListBtnHeader.onClick.AddListener(() => { OnButtonClicked("cartListBtnHeader"); });
            productDetailsView.backBtn.onClick.AddListener(() => { OnButtonClicked("backBtn"); });
            productDetailsView.orderListBtn.onClick.AddListener(() => { OnButtonClicked("orderListBtn"); });
            productDetailsView.homeBtn.onClick.AddListener(() => { OnButtonClicked("homeBtn"); });
        }
        void OnProductAdded()
        {
            AddToCart addToCart = new AddToCart();
            addToCart.name = selectedProduct.name;
            MBApplicationData.Instance.addToCartList.products.Add(addToCart);
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
            selectedProduct = productList.products.Where(x => x.id == pID).FirstOrDefault();
        }
    }

}
