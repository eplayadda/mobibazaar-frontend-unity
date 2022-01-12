using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace mb
{
    public class ProductListView : MonoBehaviour, IView
    {
       
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


