using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace mb
{
    public class BaseController : MonoBehaviour
    {
        
       public string prevScreen;
       [HideInInspector]public Router router;

        public virtual void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Back Pressed" + transform.name);
                router.ActivateScreen(prevScreen);
            }
        }
    }

}
