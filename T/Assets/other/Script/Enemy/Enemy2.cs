using UnityEngine;

public class Enemy2 : MonoBehaviour , Idamage2
{
    public Animator anim;
    public Rigidbody2D rig;
    

    [Header("移动")]
    public float speed;
    public Transform pointLeft;
    public Transform pointRight;
    private float leftX;
    private float rightX;
    public bool m_FacingRight = true;

    [Header("状态")]
    public bool isDead;
    public float health = 1;

    void  Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        leftX = pointLeft.position.x;
        rightX = pointRight.position.x;
        Destroy(pointLeft.gameObject);
        Destroy(pointRight.gameObject);
        
    }

    void Update()
    {
        IsDead();
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    //向目标点移动
    public void MoveToTarget()
    {
        if (isDead)
        {
            return;
        }
        if (m_FacingRight)
        {
            rig.velocity = new Vector2(speed * Time.fixedDeltaTime * 60, rig.velocity.y);
            if (transform.position.x >= rightX)
            {
                transform.localScale = new Vector3(1, 1, 1);
                m_FacingRight = false;
            }
        }
        else
        {
            rig.velocity = new Vector2(-speed * Time.fixedDeltaTime * 60, rig.velocity.y);
            if (transform.position.x <= leftX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                m_FacingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            m_FacingRight = !m_FacingRight;
        }
    }

    public virtual void GetHit(float damage)
    {
        health -= damage;
    }

    void IsDead()
    {
        if (health > 0)
        {
            isDead = false;
            anim.SetBool("dead", false);
            anim.SetBool("explotion", false);
            gameObject.layer = LayerMask.NameToLayer("Enemy");
            gameObject.tag = "Enemy";
        }
        else if (health == 0)
        {
            isDead = true;
            anim.SetBool("dead", true);
            gameObject.tag = "Obstacle";
        }
    }
}
