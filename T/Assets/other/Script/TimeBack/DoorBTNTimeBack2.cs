using System.Collections;
using UnityEngine;

public class DoorBTNTimeBack2 : MonoBehaviour
{
    private Stack TimeBackData;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private DoorButton2 btn;

    DoorBTNStage2 LoadStageData = new DoorBTNStage2();

    private bool CheckKey;
    private bool CheckKeyUp;

    void Awake()
    {
        TimeBackData = new Stack();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        btn = GetComponent<DoorButton2>();
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
        DoorBTNStage2 stage = new DoorBTNStage2();
        stage.Sprite = SpriteRenderer.sprite;
        stage.Btn = animator.GetBool("btn");
        TimeBackData.Push(stage);
    }

    DoorBTNStage2 LoadData()
    {
        if (TimeBackData.Count > 1)
        {
            return (DoorBTNStage2)TimeBackData.Pop();
        }
        else
        {
            return (DoorBTNStage2)TimeBackData.Peek();
        }
    }

    void ShowData(DoorBTNStage2 stage)
    {
        animator.enabled = false;
        animator.SetBool("btn", stage.Btn);
        SpriteRenderer.sprite = stage.Sprite;
    }
}
