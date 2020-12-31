using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTimeBack : MonoBehaviour
{
    private Stack stageDatas = new Stack();
    private Stack go = new Stack();
    private bool isComeIn = false;
    PlayerObjectStage stageData_Door = null;
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
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void SaveData()
    {
        PlayerObjectStage stageData = new PlayerObjectStage();
        stageData.isDead = gameObject.GetComponent<door>().isOpen;
        stageDatas.Push(stageData);
    }
    private void LoadData()
    {
        if (stageDatas.Count > 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Door = (PlayerObjectStage)stageDatas.Pop();
        }
        else if (stageDatas.Count == 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Door = (PlayerObjectStage)stageDatas.Peek();
        }
        if (stageData_Door != null)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<door>().isOpen = stageData_Door.isDead;
            gameObject.GetComponent<door>().door_Close.SetActive(!stageData_Door.isDead);
        }
    }
    private void timeGo()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (go.Count > 1)
            {
                stageData_Door = (PlayerObjectStage)go.Pop();
            }
            else if (go.Count == 1)
            {
                stageData_Door = (PlayerObjectStage)go.Peek();
            }
            if (stageData_Door != null)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<door>().isHaveKey = stageData_Door.isDead;
                gameObject.GetComponent<door>().door_Close.SetActive(!stageData_Door.isDead);
            }
        }
    }
}
