using UnityEngine;
using UnityEngine.UI;
namespace mb
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public Button logOutBtn;
        public Text logOutTxt;
        public Button backBtn;
        public Button accountBtn;
        public Button homeBtn;
        public Button orderListBtn;
        public Button cartListBtnHeader;
        public Button cartListBtnFooter;
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public string GameObjectName()
        {
            return transform.name;

        }
    }

}
