using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBtn22 : MonoBehaviour
{
    Animator anim;
    public bool button;
    public int on = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController2 player = collision.gameObject.GetComponent<PlayerController2>();

        if (collision.transform.CompareTag("Player"))
        {
            button = true;
            anim.SetBool("btn", button);
            if (anim.GetBool("btn"))
            {
                player.health = 0;
            }
        }
    }
}
