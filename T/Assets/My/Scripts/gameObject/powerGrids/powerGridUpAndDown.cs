using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerGridUpAndDown : MonoBehaviour
{
    private void Update()
    {
        upAndDown();
    }
    private void upAndDown()
    {
       gameObject.GetComponent<Transform>().Translate(Vector3.down * 0.5f, Space.Self);
    }
}