using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    private float y_Max;
    private float y_Min;
    private float x_Max;
    private float x_Min;
    private void Start()
    {
        getValue();
    }
    private void Update()
    {
        move();
    }
    private void getValue()
    {
        x_Max = gameObject.GetComponent<Transform>().position.x + 0.41f;
        x_Min = gameObject.GetComponent<Transform>().position.x - 0.62f;
        y_Max = gameObject.GetComponent<Transform>().position.y + 3.45f;
        y_Min = gameObject.GetComponent<Transform>().position.y - 1.359124f;
    }
    private void move()
    {
        if(getComponent_First.Instance.player_playerController.isDead == false)
        {
            if (getComponent_First.Instance.player_Transform.position.y <= y_Max && getComponent_First.Instance.player_Transform.position.y >= y_Min)
            {
                if (getComponent_First.Instance.player_Transform.position.x <= x_Max && getComponent_First.Instance.player_Transform.position.x >= x_Min)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        getComponent_First.Instance.player_Rigibody2D.gravityScale = 0;
                        getComponent_First.Instance.player_BoxCollider2D.enabled = false;
                        getComponent_First.Instance.player_Transform.Translate(Vector3.up * 0.02f, Space.World);
                        getComponent_First.Instance.player_Animator.SetBool("isClimb", true);
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        getComponent_First.Instance.player_Rigibody2D.gravityScale = 0;
                        getComponent_First.Instance.player_BoxCollider2D.enabled = false;
                        getComponent_First.Instance.player_Transform.Translate(Vector3.down * 0.02f, Space.World);
                        getComponent_First.Instance.player_Animator.SetBool("isClimb", true);
                    }
                    else
                    {
                        getComponent_First.Instance.player_Rigibody2D.gravityScale = 1;
                        getComponent_First.Instance.player_BoxCollider2D.enabled = true;
                        getComponent_First.Instance.player_Animator.SetBool("isClimb", false);
                    }
                }
                else
                {
                    getComponent_First.Instance.player_Rigibody2D.gravityScale = 1;
                    getComponent_First.Instance.player_BoxCollider2D.enabled = true;
                    getComponent_First.Instance.player_Animator.SetBool("isClimb", false);
                }
            }
            else
            {
                getComponent_First.Instance.player_Rigibody2D.gravityScale = 1;
                getComponent_First.Instance.player_BoxCollider2D.enabled = true;
                getComponent_First.Instance.player_Animator.SetBool("isClimb", false);
            }
        }
    }
}
