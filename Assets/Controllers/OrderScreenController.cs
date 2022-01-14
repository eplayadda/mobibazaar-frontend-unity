using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
namespace mb
{
    public class OrderScreenController : BaseController
    {
        public string orderListPath;
        OrderScreenView orderScreenView;
        public OrderList orderList;
        public GameObject order_ProtoType;
        public List<GameObject> ordersGo = new List<GameObject>();
        public Transform parent;

        private void Awake()
        {
            router = gameObject.GetComponentInParent<Router>();
            orderScreenView = (OrderScreenView)gameObject.GetComponent<IView>();

            OnClickEvents();
        }
        void OnEnable()
        {
            SetProductByID();
        }
        void SetProductByID()
        {
            var response = Resources.Load<TextAsset>(orderListPath);
            var str = "{\"orders\":" + response.text + "}";
            orderList = JsonUtility.FromJson<OrderList>(str);
            CreateProduct();
        }
        void OnClickEvents()
        {
            orderScreenView.cartListBtnFooter.onClick.AddListener(() => { OnButtonClicked("cartListBtnFooter"); });
            orderScreenView.cartListBtnHeader.onClick.AddListener(() => { OnButtonClicked("cartListBtnHeader"); });
            orderScreenView.backBtn.onClick.AddListener(() => { OnButtonClicked("backBtn"); });
            orderScreenView.orderListBtn.onClick.AddListener(() => { OnButtonClicked("orderListBtn"); });
            orderScreenView.homeBtn.onClick.AddListener(() => { OnButtonClicked("homeBtn"); });
        }

        void CreateProduct()
        {
            DestoryCategory();
            foreach (var item in orderList.orders)
            {
                GameObject go = Instantiate(order_ProtoType) as GameObject;
                var mOrderViews = go.GetComponent<OrderElementView>();
                Button button = go.GetComponent<Button>();
                mOrderViews.order = item;
                go.transform.SetParent(parent, false);
                ordersGo.Add(go);
            }

        }
        void DestoryCategory()
        {
            foreach (var item in ordersGo)
            {
                Destroy(item);
            }
            ordersGo.Clear();
        }
    }
}
