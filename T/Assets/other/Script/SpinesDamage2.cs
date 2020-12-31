using UnityEngine;

public class SpinesDamage2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController2 player = collision.gameObject.GetComponent<PlayerController2>();
        if (collision.transform.CompareTag("Player"))
        {
            player.GetHit(1);
        }
    }
}
