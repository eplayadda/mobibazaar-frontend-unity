using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace mb
{
    public class BaseController : MonoBehaviour
    {
        
       public string prevScreen;
       [HideInInspector]public Router router;

        public virtual void OnButtonClicked(string btnName)
        {
            Debug.Log("btnName ::" + btnName);
            switch (btnName)
            {
                case "checkOut":
                    router.ActivateScreen("CheckOutScreen");
                    break;
                case "logOutBtn":
                    break;
                case "cartListBtnFooter":
                    router.ActivateScreen("AddToCart");
                    break;
                case "cartListBtnHeader":
                    router.ActivateScreen("AddToCart");
                    break;
                case "menuBtn":
                    router.ActivateScreen("MainMenuScreen","Home",false);
                    break;
                case "orderListBtn":
                    router.ActivateScreen("OrderScreen");
                    break;
                case "homeBtn":
                    MBApplicationData.Instance.selectedCategoryID = 0;
                    router.ActivateScreen("Home");
                    break;
                case "backBtn":
                    router.ActivateScreen(prevScreen);
                    break;
            }
        }
        public virtual void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Back Pressed" + transform.name);
                OnButtonClicked("backBtn");
            }
        }
    }

}
