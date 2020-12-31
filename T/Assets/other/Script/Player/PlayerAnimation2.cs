using UnityEngine;

public class PlayerAnimation2 : MonoBehaviour
{

    Rigidbody2D rig;
    Animator anim;
    PlayerController2 pctr;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pctr = GetComponent<PlayerController2>();
    }

    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rig.velocity.x));
        anim.SetFloat("velocityY", rig.velocity.y);
        anim.SetBool("ground", pctr.isonGround);
        anim.SetBool("jump", pctr.isJumping);
        anim.SetBool("running", pctr.isRunning);
    }


}
