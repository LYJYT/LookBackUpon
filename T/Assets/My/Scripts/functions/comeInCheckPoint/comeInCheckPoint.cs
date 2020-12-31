using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comeInCheckPoint : MonoBehaviour
{
    public bool isOpen = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name=="Player")
        {
            if(Input.GetKeyDown(KeyCode.E)&&isOpen)
            {
                getComponent_First.Instance.camera1.isCome = true;
                getComponent_First.Instance.player_Transform.position = new Vector3(-11.3f, -3.5f, -3);
                getComponent_First.Instance.camera1.resetCamera();
            }
        }
    }
}
