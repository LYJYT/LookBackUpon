using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickUpAndDown : MonoBehaviour
{
    public bool isMove;
    public bool isStop;
    public bool up;
    private void Start()
    {
        getValue();
    }
    private void Update()
    {
        upOrDown();
    }
    private void getValue()
    {
        isMove = false;
        isStop = false;
        up = true;
    }
    private void upOrDown()
    {
        if(gameObject.GetComponent<Transform>().position.y>= -5.225f)
        {
            up = false;
        }
        else if (gameObject.GetComponent<Transform>().position.y <= -8.535f)
        {
            up = true;
        }
        if(up == true && isMove && !isStop && getComponent_First.Instance.BG.isMove)
        {
            gameObject.GetComponent<Transform>().Translate(Vector3.up * 0.03f, Space.World);
        }
        else if(up == false && isMove && !isStop && getComponent_First.Instance.BG.isMove)
        {
            gameObject.GetComponent<Transform>().Translate(Vector3.down * 0.03f, Space.World);
        }
    }
}