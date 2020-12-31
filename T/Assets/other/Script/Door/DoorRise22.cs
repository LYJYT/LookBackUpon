using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRise22 : MonoBehaviour
{
    Animator anim;
    public LayerMask LM;
    public Vector2 onGroundSize;
    public Vector2 pointSet;
    bool a;

    private void Awake()
    {
        anim = GetComponent<Animator>();    
    }
    private void Update()
    {
        a = PlayerOn();
        if (a)
        {
            anim.SetBool("Switch", true);
            //anim.StartPlayback();
            //anim.speed = 1;
        }
        else
        {
            //anim.StartPlayback();
            //anim.speed = -1;
            anim.SetBool("Switch", false);
        }
    }

    bool PlayerOn()
    {
        Collider2D coll = Physics2D.OverlapBox((Vector2)transform.position + pointSet, onGroundSize, 0, LM);
        if (coll != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //可视化判断框
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + pointSet, onGroundSize);
    }
}
