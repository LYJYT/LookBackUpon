using UnityEngine;

public class DoorRise2 : MonoBehaviour
{
    Animator anim;
    public bool rise;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            rise = true;
            anim.SetBool("Switch",rise);
        }
    }
}
