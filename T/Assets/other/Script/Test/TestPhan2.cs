using System.Collections;
using UnityEngine;

public class TestPhan2 : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rig;
    Animator anim;
    GameObject player;

    public Stack ForPhan;
    private bool CheckKey;
    bool newPhan = false;
    public float health = 1;
    public bool isDead;

    TestStage2 LoadStageData_Phan = new TestStage2();


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        ForPhan = new Stack();
    }

    private void Update()
    {
        CheckKey = Input.GetKey(KeyCode.LeftArrow);
        if (CheckKey && !newPhan)
        {
            SavePhanData();
        }
        if (!CheckKey && ForPhan.Count > 1)
        {
            newPhan = true;
            LoadStageData_Phan = LoadPhanData();
            if (LoadStageData_Phan != null)
            {
                ShowPhanData(LoadStageData_Phan);
                if (ForPhan.Count == 1 && health > 0)
                {
                    InvokeRepeating("DestroyPhan", 7f, 0);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && health >0)
        {
            DestroyPhan();
        }
    }

    public void SavePhanData()
    {
        TestStage2 stage = new TestStage2();
        stage.Position = player.transform.position;
        stage.Sprite = player.GetComponent<SpriteRenderer>().sprite;
        stage.IsRight = player.GetComponent<PlayerController2>().m_FacingRight;
        stage.Velocity = player.GetComponent<Rigidbody2D>().velocity;
        stage.health = player.GetComponent<PlayerController2>().health;
        ForPhan.Push(stage);
    }

    public TestStage2 LoadPhanData()
    {
        if (ForPhan.Count > 1)
        {
            return (TestStage2)ForPhan.Pop();
        }
        else
        {
            return (TestStage2)ForPhan.Peek();
        }
    }

    public void ShowPhanData(TestStage2 stage)
    {
        if (ForPhan.Count > 1)
        {
            anim.enabled = false;
        }
        else if (ForPhan.Count == 1)
        {
            rig.simulated = true;
        }
        transform.localScale = new Vector3(stage.IsRight ? -1 : 1, 1, 1);
        transform.position = stage.Position;
        sr.sprite = stage.Sprite;
        health = stage.health;
        rig.velocity = stage.Velocity;
    }

    void DestroyPhan()
    {
        Destroy(gameObject);
    }

}
