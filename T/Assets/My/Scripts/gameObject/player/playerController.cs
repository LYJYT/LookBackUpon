using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public bool isDead = false;
    public LayerMask platform_LayerMesk;
    public LayerMask bomb_LayerMesk;
    public LayerMask box_LayerMesk;
    private float speed= 0.001f;
    private Vector3 Right = Vector3.right;
    private Vector3 Left = Vector3.left;
    public bool isFacingRight = true;
    private bool isOnGround = true;
    private bool isOnGroundRun;
    private void Update()
    {
        onGroundAnimation();
        playerMoveAndJump();
        dead();
    }
    private void playerMoveAndJump()
    {
        if(isDead==false&&getComponent_First.Instance.BG.isMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                move(Right*speed , new Vector3(0, 180, 0));
                isFacingRight = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                move(Left*speed , new Vector3(0, 0, 0));
                isFacingRight = false;
            }
            else
            {
                getComponent_First.Instance.player_Animator.SetFloat("speed", 0);
                speed = 0.001f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Physics2D.Raycast(getComponent_First.Instance.player_BoxCollider2D.bounds.center, Vector2.down, getComponent_First.Instance.player_BoxCollider2D.bounds.extents.y + 0.05f, platform_LayerMesk) || Physics2D.Raycast(getComponent_First.Instance.player_BoxCollider2D.bounds.center, Vector2.down, getComponent_First.Instance.player_BoxCollider2D.bounds.extents.y + 0.05f, bomb_LayerMesk) || Physics2D.Raycast(getComponent_First.Instance.player_BoxCollider2D.bounds.center, Vector2.down, getComponent_First.Instance.player_BoxCollider2D.bounds.extents.y + 0.05f, box_LayerMesk))
                {
                    getComponent_First.Instance.player_Animator.SetBool("isJump", true);
                    getComponent_First.Instance.player_Rigibody2D.velocity = new Vector2(0, 6.5f);
                    StartCoroutine("isJump");
                }

            }
        }
    }
    private void changeRun()
    {
        if(speed==0.05f)
        {
            isOnGroundRun = true;
        }
        else
        {
            isOnGroundRun = false;
        }
        getComponent_First.Instance.player_Animator.SetBool("isRun", isOnGroundRun);
    }
    private void onGroundAnimation()
    {
        changeRun();
        if (Physics2D.Raycast(getComponent_First.Instance.player_BoxCollider2D.bounds.center, Vector2.down, getComponent_First.Instance.player_BoxCollider2D.bounds.extents.y + 0.05f, platform_LayerMesk) || Physics2D.Raycast(getComponent_First.Instance.player_BoxCollider2D.bounds.center, Vector2.down, getComponent_First.Instance.player_BoxCollider2D.bounds.extents.y + 0.05f, bomb_LayerMesk)|| Physics2D.Raycast(getComponent_First.Instance.player_BoxCollider2D.bounds.center, Vector2.down, getComponent_First.Instance.player_BoxCollider2D.bounds.extents.y + 0.05f, box_LayerMesk))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
        getComponent_First.Instance.player_Animator.SetBool("isOnGround", isOnGround);
    }
    private void move(Vector3 distance,Vector3 rot)
    {
        getComponent_First.Instance.player_Animator.SetFloat("speed", 1);
        getComponent_First.Instance.player_Transform.Translate(distance, Space.World);
        getComponent_First.Instance.player_Transform.rotation = Quaternion.Euler(rot);
        StartCoroutine("changeSpeed");
    }
    private IEnumerator changeSpeed()
    {
        if(speed== 0.001f)
        {
            yield return new WaitForSeconds(0.3f);
            speed = 0.05f;
        }
    }
    private IEnumerator isJump()
    {
        yield return new WaitForSeconds(0.8f);
        getComponent_First.Instance.player_Animator.SetBool("isJump", false);
        getComponent_First.Instance.player_Rigibody2D.velocity = new Vector2(0, -3.5f);
    }
    private void dead()
    {
        if(isDead==false)
        {
            Vector2 startPos = new Vector2(getComponent_First.Instance.player_BoxCollider2D.bounds.center.x, getComponent_First.Instance.player_BoxCollider2D.bounds.center.y - getComponent_First.Instance.player_BoxCollider2D.bounds.extents.y / 2);
            if (Physics2D.Raycast(startPos, Vector2.left, getComponent_First.Instance.player_BoxCollider2D.bounds.extents.x + 0.1f, bomb_LayerMesk) || Physics2D.Raycast(startPos, Vector2.right, getComponent_First.Instance.player_BoxCollider2D.bounds.extents.x + 0.1f, bomb_LayerMesk)|| getComponent_First.Instance.player_Transform.position.y <= -23.85f)
            {
                isDead = true;
                getComponent_First.Instance.player_Animator.SetBool("isDead", true);
            }
        }
    }
}
