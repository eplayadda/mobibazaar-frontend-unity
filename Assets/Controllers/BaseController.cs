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
                case "logOutBtn":
                    break;
                case "cartListBtnFooter":
                    router.ActivateScreen("AddToCart");
                    break;
                case "cartListBtnHeader":
                    router.ActivateScreen("AddToCart");
                    break;
                case "menuBtn":
                    break;
                case "orderListBtn":
                    break;
                case "homeBtn":
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
