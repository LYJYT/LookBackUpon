using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenSwitch_1 : MonoBehaviour
{
    private void Update()
    {
        stopBrickMove();
    }
    private void stopBrickMove()
    {
        if(getComponent_First.Instance.brickUpAndDown1.up==false)
        {
            getComponent_First.Instance.brickUpAndDown1.isStop = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name=="Player"&&Input.GetKeyDown(KeyCode.R))
        {
            if (getComponent_First.Instance.brickUpAndDown1.isMove==false)
            {
                getComponent_First.Instance.brickUpAndDown1.isMove = true;
            }
            else if(getComponent_First.Instance.brickUpAndDown1.isMove == true)
            {
                getComponent_First.Instance.brickUpAndDown1.isMove = false;
            }
        }
    }
}
