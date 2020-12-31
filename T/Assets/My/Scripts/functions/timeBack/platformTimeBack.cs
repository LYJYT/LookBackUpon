using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformTimeBack : MonoBehaviour
{
    private Stack stageDatas = new Stack();
    private Stack go = new Stack();
    private bool isComeIn = false;
    PlayerObjectStage stageData_Platform = null;
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
    private void timeBack()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && isComeIn)
        {
            LoadData();
        }
        else
        {
            SaveData();
        }
    }
    private void SaveData()
    {
        PlayerObjectStage stageData = new PlayerObjectStage();
        stageData.Position = gameObject.GetComponent<Transform>().position;
        stageData.isDead = gameObject.GetComponent<brickUpAndDown>().isMove;
        stageData.isFacingRight = gameObject.GetComponent<brickUpAndDown>().up;
        stageData.isStop = gameObject.GetComponent<brickUpAndDown>().isStop;
        stageDatas.Push(stageData);
    }
    private void LoadData()
    {
        if (stageDatas.Count > 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Platform = (PlayerObjectStage)stageDatas.Pop();
        }
        else if (stageDatas.Count == 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Platform = (PlayerObjectStage)stageDatas.Peek();
        }
        if (stageData_Platform != null)
        {
            gameObject.GetComponent<Transform>().position = stageData_Platform.Position;
            gameObject.GetComponent<brickUpAndDown>().isMove = stageData_Platform.isDead;
            gameObject.GetComponent<brickUpAndDown>().up = stageData_Platform.isFacingRight;
            gameObject.GetComponent<brickUpAndDown>().isStop = stageData_Platform.isStop;
        }
    }
    private void timeGo()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (go.Count > 1)
            {
                stageData_Platform = (PlayerObjectStage)go.Pop();
            }
            else if (go.Count == 1)
            {
                stageData_Platform = (PlayerObjectStage)go.Peek();
            }
            if (stageData_Platform != null)
            {
                gameObject.GetComponent<Transform>().position = stageData_Platform.Position;
                gameObject.GetComponent<brickUpAndDown>().isMove = stageData_Platform.isDead;
                gameObject.GetComponent<brickUpAndDown>().up = stageData_Platform.isFacingRight;
                gameObject.GetComponent<brickUpAndDown>().isStop = stageData_Platform.isStop;
            }
        }
    }
}
