using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetGame_1 : MonoBehaviour
{
    public key doorAndKey1;
    public key doorAndKey2;
    private void Update()
    {
        reset();
    }
    private void reset()
    {
        if(gameTime.Instance.time>=10000)
        {
            doorAndKey1.resetDoorAndKey();
            doorAndKey2.resetDoorAndKey();
            getComponent_First.Instance.player_playerController.isDead = false;
            getComponent_First.Instance.player_Animator.SetBool("isDead", false);
            getComponent_First.Instance.player_Transform.position = new Vector3(-10.64f, -3.529124f, -3);
            getComponent_First.Instance.phantom1.isPhantom = true;
            getComponent_First.Instance.camera1.resetCamera();
            getComponent_First.Instance.BG.isMove = true;
            gameTime.Instance.time = 0;
        }
        if(getComponent_First.Instance.player_playerController.isDead == true)
        {
            getObject_First.Instance.object_Text.SetActive(true);
        }
        else if (getComponent_First.Instance.player_playerController.isDead == false)
        {
            getObject_First.Instance.object_Text.SetActive(false);
        }
    }
}
