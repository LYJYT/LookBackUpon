using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTimeBack2 : MonoBehaviour
{
    private Stack TimeBackData;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private Trap2 trap;

    TrapStage2 LoadStageData = new TrapStage2();

    private bool CheckKey;
    private bool CheckKeyUp;

    void Awake()
    {
        TimeBackData = new Stack();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        trap = GetComponent<Trap2>();
    }


    void Update()
    {
        CheckKey = Input.GetKey(KeyCode.LeftArrow);
        CheckKeyUp = Input.GetKeyUp(KeyCode.LeftArrow);
        if (CheckKeyUp)
        {
            animator.enabled = true;
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
        TrapStage2 stage = new TrapStage2();
        stage.Sprite = SpriteRenderer.sprite;
        stage.Speed = animator.speed;
        TimeBackData.Push(stage);
    }

    TrapStage2 LoadData()
    {
        if (TimeBackData.Count > 1)
        {
            return (TrapStage2)TimeBackData.Pop();
        }
        else
        {
            return (TrapStage2)TimeBackData.Peek();
        }
    }

    void ShowData(TrapStage2 stage)
    {
        animator.enabled = false;
        SpriteRenderer.sprite = stage.Sprite;
        animator.speed = stage.Speed;
    }
}
