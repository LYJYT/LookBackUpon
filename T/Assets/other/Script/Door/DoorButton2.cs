using UnityEngine;

public class DoorButton2 : MonoBehaviour
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
        PlayerController2 player = GetComponent<PlayerController2>();

        if (collision.transform.CompareTag("Player"))
        {
            button = true;
            anim.SetBool("btn", button);
            if (anim.GetBool("btn"))
            {
                on = 1;
            }
        }
    }
}
