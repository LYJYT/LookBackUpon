using System.Collections;
using UnityEngine;

public class TrapConTimeBack2 : MonoBehaviour
{
    private Stack TimeBackData;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private TrapController2 trap;
    private Rigidbody2D m_Rigidbody2D;

    TrapConStage2 LoadStageData = new TrapConStage2();

    private bool CheckKey;
    private bool CheckKeyUp;

    void Awake()
    {
        TimeBackData = new Stack();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        trap = GetComponent<TrapController2>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CheckKey = Input.GetKey(KeyCode.LeftArrow);
        CheckKeyUp = Input.GetKeyUp(KeyCode.LeftArrow);
        if (CheckKeyUp)
        {
            animator.enabled = true;
            m_Rigidbody2D.simulated = true;
        }
    }

    private void FixedUpdate()
    {
        if (CheckKey && GameObject.Find("BG").GetComponent<BGColor>().isMove == false)
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
        TrapConStage2 stage = new TrapConStage2();
        stage.Position = transform.position;
        stage.Sprite = SpriteRenderer.sprite;
        stage.health = trap.health;
        TimeBackData.Push(stage);
    }

    TrapConStage2 LoadData()
    {
        if (TimeBackData.Count > 1)
        {
            return (TrapConStage2)TimeBackData.Pop();
        }
        else
        {
            return (TrapConStage2)TimeBackData.Peek();
        }
    }

    void ShowData(TrapConStage2 stage)
    {
        animator.enabled = false;
        transform.position = stage.Position;
        SpriteRenderer.sprite = stage.Sprite;
        m_Rigidbody2D.simulated = false;
        trap.health = stage.health;
    }
}
