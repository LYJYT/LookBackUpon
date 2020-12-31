using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombB : MonoBehaviour
{
    private bool isJump = true;
    private void Update()
    {
        dead();
    }
    private void dead()
    {
        if (gameObject.GetComponent<bomb>().isDead == true && isJump)
        {
            isJump = false;
            getComponent_First.Instance.player_Rigibody2D.velocity = new Vector2(0, 6);
            gameObject.GetComponent<Animator>().SetBool("isBeBox", true);
            gameObject.layer = LayerMask.NameToLayer("box");
        }
    }
}
