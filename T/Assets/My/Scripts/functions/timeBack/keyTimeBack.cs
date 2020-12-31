using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyTimeBack : MonoBehaviour
{
    private Stack stageDatas = new Stack();
    private Stack go = new Stack();
    private bool isComeIn = false;
    PlayerObjectStage stageData_Key = null;
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
        stageData.isDead = gameObject.GetComponent<key>().isHaveKey;
        stageDatas.Push(stageData);
    }
    private void LoadData()
    {
        if (stageDatas.Count > 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Key = (PlayerObjectStage)stageDatas.Pop();
        }
        else if (stageDatas.Count == 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Key = (PlayerObjectStage)stageDatas.Peek();
        }
        if (stageData_Key != null)
        {
            gameObject.GetComponent<key>().isHaveKey = stageData_Key.isDead;
        }
    }
    private void timeGo()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (go.Count > 1)
            {
                stageData_Key = (PlayerObjectStage)go.Pop();
            }
            else if (go.Count == 1)
            {
                stageData_Key = (PlayerObjectStage)go.Peek();
            }
            if (stageData_Key != null)
            {
                gameObject.GetComponent<key>().isHaveKey = stageData_Key.isDead;
            }
        }
    }
}
