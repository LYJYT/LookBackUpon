using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn22 : MonoBehaviour
{
    Animator anim;
    public bool open;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Phantom"))
        {
            anim.SetTrigger("open");
            open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Phantom"))
        {
            anim.SetTrigger("open");
            open = false;
        }
    }
}
