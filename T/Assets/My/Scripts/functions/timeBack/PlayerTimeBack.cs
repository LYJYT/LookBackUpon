using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeBack : MonoBehaviour
{
    private bool isSave = false;
    private Stack stageDatas = new Stack();
    private Stack go = new Stack();
    private bool isComeIn = false;
    PlayerObjectStage stageData_Player = null;
    void Update()
    {
        changeIsSave();
        comeInTimeBack();
        timeBack();
        timeGo();
        goOutTimeBack();
    }
    private void changeIsSave()
    {
        if(getComponent_First.Instance.player_Transform.position.x== -11.3f)
        {
            isSave = true;
        }
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
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(isComeIn==false)
            {
                isComeIn = true;
            }
            else if(isComeIn==true)
            {
                isComeIn = false;
            }
        }
    }
    private void timeBack()
    {
        if (Input.GetKey(KeyCode.LeftArrow)&&isComeIn)
        {
            LoadData();
        }
        else
        {
            SaveData();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.RightArrow))
        {
            getComponent_First.Instance.player_Animator.enabled = true;
            getComponent_First.Instance.player_Rigibody2D.simulated = true;
        }
    }
    private void SaveData()
    {
        if(isSave)
        {
            PlayerObjectStage stageData = new PlayerObjectStage();
            stageData.Position = getComponent_First.Instance.player_Transform.position;
            stageData.isFacingRight = getComponent_First.Instance.player_playerController.isFacingRight;
            stageData.Sprite = getComponent_First.Instance.player_SpriteRenderer.sprite;
            stageData.isDead = getComponent_First.Instance.player_playerController.isDead;
            stageDatas.Push(stageData);
        }
    }
    private void LoadData()
    {
        if (stageDatas.Count > 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Player = (PlayerObjectStage)stageDatas.Pop();
        }
        else if(stageDatas.Count == 1)
        {
            go.Push((PlayerObjectStage)stageDatas.Peek());
            stageData_Player = (PlayerObjectStage)stageDatas.Peek();
        }
        if (stageData_Player != null)
        {
            getComponent_First.Instance.player_Animator.enabled = false;
            getComponent_First.Instance.player_Rigibody2D.simulated = false;
            getComponent_First.Instance.player_Transform.position = stageData_Player.Position;
            getComponent_First.Instance.player_SpriteRenderer.sprite = stageData_Player.Sprite;
            getComponent_First.Instance.player_playerController.isDead = stageData_Player.isDead;
            getComponent_First.Instance.player_Animator.SetBool("isDead", stageData_Player.isDead);
            if (stageData_Player.isFacingRight)
            {
                getComponent_First.Instance.player_Transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                getComponent_First.Instance.player_Transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    private void timeGo()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (go.Count > 1)
            {
                stageData_Player = (PlayerObjectStage)go.Pop();
            }
            else if(go.Count==1)
            {
                stageData_Player = (PlayerObjectStage)go.Peek();
            }
            if (stageData_Player != null)
            {
                getComponent_First.Instance.player_Animator.enabled = false;
                getComponent_First.Instance.player_Rigibody2D.simulated = false;
                getComponent_First.Instance.player_Transform.position = stageData_Player.Position;
                getComponent_First.Instance.player_SpriteRenderer.sprite = stageData_Player.Sprite;
                getComponent_First.Instance.player_playerController.isDead = stageData_Player.isDead;
                getComponent_First.Instance.player_Animator.SetBool("isDead", stageData_Player.isDead);
                if (stageData_Player.isFacingRight)
                {
                    getComponent_First.Instance.player_Transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    getComponent_First.Instance.player_Transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }
}
