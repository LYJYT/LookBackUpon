using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject btn;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (btn.gameObject.GetComponent<btn22>().open)
        {
            anim.SetTrigger("move");
        }
    }
}
