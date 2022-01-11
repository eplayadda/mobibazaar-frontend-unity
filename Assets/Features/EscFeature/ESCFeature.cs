using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ESCFeature : MonoBehaviour
{
    Router router;

    void Start()
    {
        router = gameObject.GetComponentInParent<Router>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Back Pressed");
            router.BackPressed();
        }
    }
}
