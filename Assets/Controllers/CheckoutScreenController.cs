using System.Linq;
using UnityEngine;
namespace mb
{

    public class CheckoutScreenController : BaseController
    {
        [HideInInspector] CheckoutScreenView checkoutScreenView;

        private void Awake()
        {
            router = gameObject.GetComponentInParent<Router>();
            checkoutScreenView = (CheckoutScreenView)gameObject.GetComponent<IView>();

            OnClickEvents();

        }
        void OnEnable()
        {
            DisplayOrderItem();
        }
        void OnClickEvents()
        {
            checkoutScreenView.placeOrder.onClick.AddListener(() => { OnPlaceOrder(); });
            checkoutScreenView.cartListBtnFooter.onClick.AddListener(() => { OnButtonClicked("cartListBtnFooter"); });
            checkoutScreenView.cartListBtnHeader.onClick.AddListener(() => { OnButtonClicked("cartListBtnHeader"); });
            checkoutScreenView.backBtn.onClick.AddListener(() => { OnButtonClicked("backBtn"); });
            checkoutScreenView.orderListBtn.onClick.AddListener(() => { OnButtonClicked("orderListBtn"); });
            checkoutScreenView.homeBtn.onClick.AddListener(() => { OnButtonClicked("homeBtn"); });
        }
        void OnPlaceOrder()
        {
            Debug.Log("Place Order");
        }

      
        void DisplayOrderItem()
        {
            Debug.Log("Show Order details");
        }
        
    }
}
