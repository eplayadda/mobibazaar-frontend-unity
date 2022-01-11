using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
   public void OnActivation()
    {
        gameObject.SetActive(true);
    }

    public void OnDeactivation()
    {
        gameObject.SetActive(false);
    }
}
