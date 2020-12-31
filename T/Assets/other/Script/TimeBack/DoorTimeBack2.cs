using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTimeBack2 : MonoBehaviour
{
    private Stack TimeBackData;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;

    DoorSatge2 LoadStageData = new DoorSatge2();

    private bool CheckKey;
    private bool CheckKeyUp;

    void Awake()
    {
        TimeBackData = new Stack();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        DoorSatge2 stage = new DoorSatge2();
        stage.Sprite = SpriteRenderer.sprite;
        stage.Switch = animator.GetBool("Switch");
        TimeBackData.Push(stage);
    }

    DoorSatge2 LoadData()
    {
        if (TimeBackData.Count > 1)
        {
            return (DoorSatge2)TimeBackData.Pop();
        }
        else
        {
            return (DoorSatge2)TimeBackData.Peek();
        }
    }

    void ShowData(DoorSatge2 stage)
    {
        animator.enabled = false;
        animator.SetBool("Switch", stage.Switch);
        SpriteRenderer.sprite = stage.Sprite;
    }
}
