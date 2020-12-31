using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickLeftAndRight : MonoBehaviour
{
    public bool isMove = false;
    private bool left = false;
    private void Update()
    {
        leftOrRight();
    }
    private void leftOrRight()
    {
        if (gameObject.GetComponent<Transform>().position.y >= -5.225f)
        {
            left = false;
        }
        else if (gameObject.GetComponent<Transform>().position.y <= -8.535f)
        {
            left = true;
        }
        if (left == true && isMove)
        {
            gameObject.GetComponent<Transform>().Translate(Vector3.left * 0.03f, Space.World);
        }
        else if (left == false && isMove)
        {
            gameObject.GetComponent<Transform>().Translate(Vector3.right * 0.03f, Space.World);
        }
    }
}
