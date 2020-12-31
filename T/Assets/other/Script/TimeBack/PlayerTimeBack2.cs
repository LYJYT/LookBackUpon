using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayerTimeBack2 : MonoBehaviour
{
    public Stack TimeBackData;
    public GameObject Phan;
    public Transform Phantoms;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private PlayerController2 cc2D;
    private Rigidbody2D m_Rigidbody2D;

    private bool CheckKey;
    private bool CheckKeyUp;

    PlayerObjectStage2 LoadStageData_Player = new PlayerObjectStage2();

    [Header("判断是否使用胶囊")]
    public bool canTimeBack;

    void Awake()
    {
        TimeBackData = new Stack();
    }

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        cc2D = GetComponent<PlayerController2>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CheckKey = Input.GetKey(KeyCode.LeftArrow);
        CheckKeyUp = Input.GetKeyUp(KeyCode.LeftArrow);

        if (CheckKeyUp)
        {
            cc2D.m_FacingRight = LoadStageData_Player.IsRight;
            animator.enabled = true;
            m_Rigidbody2D.simulated = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject phan = Instantiate(Phan, new Vector2(-17f,-6f), Quaternion.identity);
            phan.transform.SetParent(Phantoms);
        }
    }

    private void FixedUpdate()
    {
        if (CheckKey && canTimeBack && GameObject.Find("BG").GetComponent<BGColor>().isMove == false)
        {
            LoadStageData_Player = LoadData();
            if (LoadStageData_Player != null)
            {
                ShowData(LoadStageData_Player);
            }
        }
        else
        {
            SaveData();
        }
    }

    public void SaveData()
    {
        PlayerObjectStage2 stage = new PlayerObjectStage2();
        stage.Position = transform.position;
        stage.Sprite = SpriteRenderer.sprite;
        stage.IsRight = cc2D.m_FacingRight;
        stage.Velocity = m_Rigidbody2D.velocity;
        stage.health = cc2D.health;
        TimeBackData.Push(stage);
    }

    public PlayerObjectStage2 LoadData()
    {
        if (TimeBackData.Count > 1)
        {
            return (PlayerObjectStage2)TimeBackData.Pop();
        }
        else
        {
            return (PlayerObjectStage2)TimeBackData.Peek();
        }
    }

    public void ShowData(PlayerObjectStage2 stage)
    {
        animator.enabled = false;
        //m_Rigidbody2D.simulated = false;
        transform.localScale = new Vector3(stage.IsRight ? -1 : 1, 1, 1);
        transform.position = stage.Position;
        SpriteRenderer.sprite = stage.Sprite;
        cc2D.health = stage.health;
        m_Rigidbody2D.velocity = stage.Velocity;
    }

    //使用胶囊
    bool UseCapsule()
    {
        Debug.Log("使用了胶囊");
        return true;
    }

}
