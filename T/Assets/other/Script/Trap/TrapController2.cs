using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController2 : MonoBehaviour
{
    public bool canChange;

    public float health;
    public bool isDead;

    Animator anim;
    Rigidbody2D rig;

    public GameObject trap;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        IsDead();
    }

    public void GetHit(float damage)
    {
        health -= damage;
        if (health == 0)
        {
            isDead = true;
        }
        else if (health > 0)
        {
            isDead = false;
        }
    }

    void IsDead()
    {
        if (health > 0)
        {
            isDead = false;
            anim.SetBool("dead", false);
            gameObject.layer = LayerMask.NameToLayer("Ground");
        }
        else if (health <= 0)
        {
            isDead = true;
            anim.SetBool("dead", true);
            //gameObject.layer = LayerMask.NameToLayer("TrapConDead");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isDead && canChange && collision.gameObject.tag=="Player")
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                trap.GetComponent<Trap2>().speed = 2f;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                trap.GetComponent<Trap2>().speed = 0.5f;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                trap.GetComponent<Trap2>().speed = 0;
            }
        }
    }

    public void TurnOn()
    {
        canChange = true;
    }

}
