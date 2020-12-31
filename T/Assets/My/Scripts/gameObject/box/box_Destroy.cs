using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_Destroy : MonoBehaviour
{
    private bool isDestroy = false;
    private void Update()
    {
        destroyObject();
    }
    private void destroyObject()
    {
        if (isDestroy)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
