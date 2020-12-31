using UnityEngine;

public class Ladder2 : MonoBehaviour
{
    public float climbSpeed;
    public Collider2D ground;

    //增加爬梯子动画后改逻辑
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D Rig = collision.GetComponent<Rigidbody2D>();

        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
            {
                Rig.gravityScale = 0;
                Rig.velocity = new Vector2(0, climbSpeed);
                Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), ground);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Rig.gravityScale = 0;
                Rig.velocity = new Vector2(0, -climbSpeed);
                Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), ground);
            }
            else /* if((Rig.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_Climbup") ||  Rig.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_ClimbDown")) && 
            (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S)))*/  
            //增加爬梯子动画后改逻辑
            {
                Rig.velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x , 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D Rig = collision.GetComponent<Rigidbody2D>();

        if (collision.gameObject.tag == "Player")
        {
            Rig.gravityScale = 1;
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), ground,false);
        }
    }

}