using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spines : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            getComponent_First.Instance.player_playerController.isDead = true;
            getComponent_First.Instance.player_Animator.SetBool("isDead", true);
        }
    }
}
