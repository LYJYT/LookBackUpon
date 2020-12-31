using UnityEngine;

public class Trap2 : MonoBehaviour 
{

    [Header("移动")]
    public float speed;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.speed = speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController2 player = collision.gameObject.GetComponent<PlayerController2>();
        TrapController2 trap = collision.gameObject.GetComponent<TrapController2>();

        if (collision.gameObject.tag == "Player")
        {
            player.GetHit(1);
        }
        if (collision.gameObject.tag == "Trap")
        {
            trap.GetHit(1);
        }
    }
}
