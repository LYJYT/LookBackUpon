using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public bool isDead = false;
    public LayerMask player_LayerMask;
    private Transform m_Transform;
    public Transform left_Transform;
    public Transform right_Transform;
    public float left;
    public float right;
    public bool isRight = false;
    public bool isFacingRight = false;
    private void Awake()
    {
        getValue();
    }
    private void Update()
    {
        move();
        changeFancing();
        dead();
    }
    private void getValue()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        left = left_Transform.position.x;
        right = right_Transform.position.x;
    }
    private void move()
    {
        if(getComponent_First.Instance.BG.isMove)
        {
            if (isDead == false)
            {
                if (isRight==false)
                {
                    m_Transform.Translate(Vector3.left * 0.02f, Space.World);
                    if (m_Transform.position.x <= left)
                    {
                        isRight = true;
                        isFacingRight = true;
                    }
                }
                else if (isRight==true)
                {
                    m_Transform.Translate(Vector3.right * 0.02f, Space.World);
                    if (m_Transform.position.x >= right)
                    {
                        isRight = false;
                        isFacingRight = false;
                    }
                }
            }
        }
    }
    private void changeFancing()
    {
        if(isFacingRight==true)
        {
            m_Transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(isFacingRight == false)
        {
            m_Transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void dead()
    {
        if (Physics2D.Raycast(gameObject.GetComponent<BoxCollider2D>().bounds.center, Vector2.up, gameObject.GetComponent<BoxCollider2D>().bounds.extents.y + 0.1f, player_LayerMask))
        {
            isDead = true;
        }
    }
}
