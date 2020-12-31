using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTimeBack2 : MonoBehaviour
{
    private Stack TimeBackData;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;
    private PlayerController2 cc2D;
    private Rigidbody2D m_Rigidbody2D;

    PlatformObjectStage2 LoadStageData = new PlatformObjectStage2();

    private bool CheckKey;
    private bool CheckKeyUp;

    void Start()
    {
        TimeBackData = new Stack();
        cc2D = GetComponent<PlayerController2>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CheckKey = Input.GetKey(KeyCode.LeftArrow);
        CheckKeyUp = Input.GetKeyUp(KeyCode.LeftArrow);
        if (CheckKeyUp)
        {
            m_Rigidbody2D.simulated = true;
        }
    }

    private void FixedUpdate()
    {
        if (CheckKey)
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
        PlatformObjectStage2 stage = new PlatformObjectStage2();
        stage.Position = transform.position;
        stage.Velocity = m_Rigidbody2D.velocity;
        TimeBackData.Push(stage);
    }

    PlatformObjectStage2 LoadData()
    {
        if (TimeBackData.Count > 1)
        {
            return (PlatformObjectStage2)TimeBackData.Pop();
        }
        else
        {
            return (PlatformObjectStage2)TimeBackData.Peek();
        }
    }

    void ShowData(PlatformObjectStage2 stage)
    {
        transform.position = stage.Position;
        m_Rigidbody2D.simulated = false;
        m_Rigidbody2D.velocity = stage.Velocity;
    }
}