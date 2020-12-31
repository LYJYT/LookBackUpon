using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTimeBack : MonoBehaviour
{
    private Stack stageDatas = new Stack();
    private Stack go = new Stack();
    private bool isComeIn = false;
    PlayerObjectStage stageData_Enemy = null;
    void Update()
    {
        comeInTimeBack();
        timeBack();
        timeGo();
        goOutTimeBack();
    }
    private void goOutTimeBack()
    {
        if (gameTime.Instance.time >= 10000)
        {
            isComeIn = false;
            stageDatas.Clear();
            go.Clear();
        }
    }
    private void comeInTimeBack()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isComeIn == false)
            {
                isComeIn = true;
            }
            else if (isComeIn == true)
            {
                isComeIn = false;
            }
        }
    }
    void timeBack()
    {
        if (Input.GetKey(KeyCode.LeftArrow)&&isComeIn)
        {
            LoadData();
        }
        else
        {
            SaveData();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<Animator>().enabled = true;
        }
    }
    void SaveData()
    {
        PlayerObjectStage stage = new PlayerObjectStage();
        stage.Position = transform.position;
        stage.Sprite = GetComponent<SpriteRenderer>().sprite;
        stage.isDead = GetComponent<bomb>().isDead;
        stage.isFacingRight = GetComponent<bomb>().isFacingRight;
        stageDatas.Push(stage);
    }
    void LoadData()
    {
        if (stageDatas.Count > 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Enemy = (PlayerObjectStage)stageDatas.Pop();
        }
        else
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Enemy = (PlayerObjectStage)stageDatas.Peek();
        }
        if (stageData_Enemy != null)
        {
            GetComponent<Animator>().enabled = false;
            transform.position = stageData_Enemy.Position;
            GetComponent<SpriteRenderer>().sprite = stageData_Enemy.Sprite;
            GetComponent<bomb>().isDead = stageData_Enemy.isDead;
            GetComponent<bomb>().isFacingRight = stageData_Enemy.isFacingRight;
            GetComponent<bomb>().isRight = stageData_Enemy.isFacingRight;
            if (stageData_Enemy.isFacingRight)
            {
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    void timeGo()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (go.Count > 1)
            {
                stageData_Enemy = (PlayerObjectStage)go.Pop();
            }
            else if(go.Count == 1)
            {
                stageData_Enemy = (PlayerObjectStage)go.Peek();
            }
            if (stageData_Enemy != null)
            {
                GetComponent<Animator>().enabled = false;
                transform.position = stageData_Enemy.Position;
                GetComponent<SpriteRenderer>().sprite = stageData_Enemy.Sprite;
                GetComponent<bomb>().isDead = stageData_Enemy.isDead;
                GetComponent<bomb>().isFacingRight = stageData_Enemy.isFacingRight;
                GetComponent<bomb>().isRight = stageData_Enemy.isFacingRight;
                if (stageData_Enemy.isFacingRight)
                {
                    gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }
}
