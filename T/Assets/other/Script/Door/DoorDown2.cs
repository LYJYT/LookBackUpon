using UnityEngine;

public class DoorDown2 : MonoBehaviour
{
    Animator anim;
    public bool down;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            down = true;
            anim.SetBool("Switch", down);
        }
    }
}
