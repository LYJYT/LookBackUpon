using System.Collections;
using UnityEngine;

public class EnemyTimeBack2 : MonoBehaviour
{
    private Stack TimeBackData;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private Enemy2 em;
    private Rigidbody2D m_Rigidbody2D;

    EnemyObjectStage2 LoadStageData = new EnemyObjectStage2();

    private bool CheckKey;
    private bool CheckKeyUp;

    void Awake()
    {
        TimeBackData = new Stack();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        em = GetComponent<Enemy2>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CheckKey = Input.GetKey(KeyCode.LeftArrow);
        CheckKeyUp = Input.GetKeyUp(KeyCode.LeftArrow);
        if (CheckKeyUp)
        {
            em.m_FacingRight = LoadStageData.IsRight;
            animator.enabled = true;
            m_Rigidbody2D.simulated = true;
        }
    }

    private void FixedUpdate()
    {
        if (CheckKey&& GameObject.Find("BG").GetComponent<BGColor>().isMove==false)
        {
            LoadStageData = LoadData();
            if (LoadStageData != null)
            {
                ShowData(LoadStageData);
            }
        }
        else
        {
            SaveData();
        }
    }

    void SaveData()
    {
        EnemyObjectStage2 stage = new EnemyObjectStage2();
        stage.Position = transform.position;
        stage.Sprite = SpriteRenderer.sprite;
        stage.IsRight = em.m_FacingRight;
        stage.health = em.health;
        TimeBackData.Push(stage);
    }

    EnemyObjectStage2 LoadData()
    {
        if (TimeBackData.Count > 1)
        {
            return (EnemyObjectStage2)TimeBackData.Pop();
        }
        else
        {
            return (EnemyObjectStage2)TimeBackData.Peek();
        }
    }

    void ShowData(EnemyObjectStage2 stage)
    {
        animator.enabled = false;
        transform.position = stage.Position;
        SpriteRenderer.sprite = stage.Sprite;
        transform.localScale = new Vector3(stage.IsRight ? -1 : 1, 1, 1);
        m_Rigidbody2D.simulated = false;
        em.health = stage.health;
    }
}