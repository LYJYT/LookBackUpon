using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour , Idamage2
{
    Rigidbody2D rig;
    Animator anim;

    [Header("移动")]
    public float moveSpeed;
    public float climbSpeed;
    float velocityX;
    float velocityY;
    public float bufferTime;
    public bool m_FacingRight = true;

    [Header("触地判断")]
    public LayerMask groundLM;
    private Vector2 onGroundSize = new Vector2(0.52f,0.4f);
    private Vector2 pointSet = new Vector2(-0.017f,-1.2f);
    [SerializeField]
    public bool isonGround;

    [Header("跳跃")]
    public float fallMultiplier;
    public float lowMultiplier;
    public bool isJumping;
    public bool isRunning;

    [Header("人物状态")]
    public bool isDead;
    public float health = 1;

    [Header("UI")]
    public GameObject myBag;
    public GameObject tip_timeback;
    public bool isOpen;
    public GameObject keyCanues;
    public bool canUseKey;
    public bool canUseKey2;
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        OpenBag();
        IsDead();
        Face();
    }

    private void FixedUpdate()
    {

        if (isDead)
        {
            gameObject.layer = LayerMask.NameToLayer("Environment");
            rig.velocity = new Vector2(0, -5);
            return;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

        isonGround = OnGround();
        MoveMent();
        Jump();
    }


    //触地判断
    bool OnGround()
    {
        Collider2D coll = Physics2D.OverlapBox((Vector2)transform.position + pointSet, onGroundSize, 0, groundLM);
        if (coll != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //可视化判断框
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + pointSet, onGroundSize);
    }

    //触发器 damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy2 enemy = collision.gameObject.GetComponent<Enemy2>();

        //敌人相关
        if (collision.gameObject.tag == "Enemy")
        {
            //处于下落时碰撞击杀敌人
            if (anim.GetFloat("velocityY")<-0.01)
            {
                enemy.GetHit(1);
                rig.velocity = new Vector2(rig.velocity.x,8f);
            }
            //角色碰撞敌人死亡
            else
            {
                GetHit(1);
                isDead = true;
            }
        }

        //碰到刺死亡
        else if (collision.gameObject.tag == "Spines")
        {
            GetHit(1);
            isDead = true;
        }
    }

    //受伤判定
    public void GetHit(float damage)
    {
        health -= damage;
        if (health == 0)
        {
            isDead = true;
        }
        else if (health > 0)
        {
            isDead = false;
        }
    }
    //死亡相关
    void IsDead()
    {
        if (health <= 0)
        {
            InvokeRepeating("ChangeType", 0.5f , 0);
            isDead = true;
            tip_timeback.SetActive(true);
        }
        else
        {
            rig.bodyType = RigidbodyType2D.Dynamic;
            isDead = false;
            tip_timeback.SetActive(false);
        }
        anim.SetBool("dead", isDead);
    }

    void ChangeType()
    {
        rig.bodyType = RigidbodyType2D.Static;
    }

    //面向
    void Face()
    {
        if (transform.localScale.x > 0.01f)
        {
            m_FacingRight = false;
        }
        else if (transform.localScale.x < -0.01f)
        {
            m_FacingRight = true;
        }
            
    }

    //跳跃
    void Jump()
    {
        if (isonGround&&GameObject.Find("BG").GetComponent<BGColor>().isMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.velocity = new Vector2(rig.velocity.x, 6.5f);
                isJumping = true;
                StartCoroutine("isJumpEnd");
            }
        }
    }
    private IEnumerator isJumpEnd()
    {
        yield return new WaitForSeconds(0.8f);
        isJumping = false;
        rig.velocity = new Vector2(0, -3.5f);
    }

    //移动
    void MoveMent()
    {
        if (Input.GetKey(KeyCode.D)&& GameObject.Find("BG").GetComponent<BGColor>().isMove)
        {
            rig.velocity = new Vector2(Mathf.SmoothDamp(rig.velocity.x, moveSpeed * Time.fixedDeltaTime * 60, ref velocityX, bufferTime), rig.velocity.y);
            rig.transform.localScale = new Vector3(-1, 1, 0);
            isRunning = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector2(Mathf.SmoothDamp(rig.velocity.x, moveSpeed * Time.fixedDeltaTime * 60 * -1, ref velocityX, bufferTime), rig.velocity.y);
            rig.transform.localScale = new Vector3(1, 1, 0);
            isRunning = true;
        }
        else
        {
            rig.velocity = new Vector2(Mathf.SmoothDamp(rig.velocity.x, 0, ref velocityX, bufferTime), rig.velocity.y);
            isRunning = false;
        }
    }
    
    //按I 打开/关闭 背包
    void OpenBag()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            canUseKey = true;
        }
        if (collision.CompareTag("Trap"))
        {
            canUseKey2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            canUseKey = false;
        }
        if (collision.CompareTag("Trap"))
        {
            canUseKey2 = false;
        }
    }

}
