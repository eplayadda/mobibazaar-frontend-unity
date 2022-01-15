using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace mb
{
    public class MainMenuScreenController : BaseController
    {
        [HideInInspector] MainMenuScreenView mainMenuScreenView;

        private void Awake()
        {
            router = gameObject.GetComponentInParent<Router>();
            mainMenuScreenView = (MainMenuScreenView)gameObject.GetComponent<IView>();

            OnClickEvents();
        }
        void OnClickEvents()
        {
            mainMenuScreenView.cartListBtnFooter.onClick.AddListener(() => { OnButtonClicked("cartListBtnFooter"); });
            mainMenuScreenView.backBtn.onClick.AddListener(() => { OnButtonClicked("backBtn"); });
            mainMenuScreenView.orderListBtn.onClick.AddListener(() => { OnButtonClicked("orderListBtn"); });
            mainMenuScreenView.homeBtn.onClick.AddListener(() => { OnButtonClicked("homeBtn"); });
        }
    }
}

