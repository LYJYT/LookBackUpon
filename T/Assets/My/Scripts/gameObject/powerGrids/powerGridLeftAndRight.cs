using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerGridLeftAndRight : MonoBehaviour
{
    private void Update()
    {
        leftAndRight();
    }
    private void leftAndRight()
    {
        gameObject.GetComponent<Transform>().Translate(Vector3.right * 0.5f, Space.Self);
    }
}
