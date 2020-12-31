using UnityEngine;

public class LiftingPlatform2 : MonoBehaviour
{
    Rigidbody2D rig;
    [Header("移动")]
    public float speed;
    public Transform pointTop;
    public Transform pointBottom;
    private bool FaceTop;
    private float topY;
    private float bottomY;

    [Header("开关状态")]
    public bool switchOn;
    public GameObject switchA;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        topY = pointTop.position.y;
        bottomY = pointBottom.position.y;
        Destroy(pointTop.gameObject);
        Destroy(pointBottom.gameObject);

    }

    void Update()
    {
        SwitchOn();
    }

    //向目标点移动
    public void MoveToTarget()
    {
        if (FaceTop)
        {
            rig.velocity = new Vector2( 0 , speed );
            if (transform.position.y > topY)
            {
                FaceTop = false;
            }
        }
        else
        {
            rig.velocity = new Vector2( 0 , -speed );
            if (transform.position.y < bottomY)
            {
                FaceTop = true;
            }
        }

    }

    void SwitchOn()
    {
        switchOn = switchA.GetComponent<Switch2>().SwitchOn;
        if (!switchOn)
        {
            rig.velocity = Vector2.zero;
            return;
        }
        MoveToTarget();
    }
}