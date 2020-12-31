using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public bool isCome = false;
    public bool isRead = false;
    public bool isUse = false;
    private Vector3 offset;
    private Vector3 startPos;
    private Vector3 roomOffset;
    private void Awake()
    {
        getValue();
    }
    private void Update()
    {
        comeInCheckPoint();
        inRoom();
    }
    private void getValue()
    {
        startPos = new Vector3(-5.18f, -0.47f, -30);
        offset = new Vector3(-5.18f, -0.47f, -30) - new Vector3(-5.702182f, 0.05333415f, -3);
        roomOffset = new Vector3(-35.87f, -0.25f, -30) - new Vector3(-35, -1.4f, -3);
    }
    public void resetCamera()
    {
        getComponent_First.Instance.camera_Transform.position = startPos;
    }
    private void comeInCheckPoint()
    {
        if(getComponent_First.Instance.player_playerController.isDead==false)
        {
            if(isCome==true)
            {
                gameObject.GetComponent<Camera>().orthographicSize = 5.036529f;
                if (getComponent_First.Instance.player_Transform.position.x <= -5.702182f)
                {
                    changeY(startPos.x, (getComponent_First.Instance.player_Transform.position + offset).y);
                }
                else if (getComponent_First.Instance.player_Transform.position.x > -5.702182f)
                {
                    changeY((getComponent_First.Instance.player_Transform.position + offset).x, (getComponent_First.Instance.player_Transform.position + offset).y);
                }
            }
        }
    }
    private void changeY(float x,float y)
    {
        if (getComponent_First.Instance.player_Transform.position.y >= 0.05333415f)
        {
            getComponent_First.Instance.camera_Transform.position = new Vector3(x, y, -30);
        }
        else if(getComponent_First.Instance.player_Transform.position.y <= -3.55f)
        {
            getComponent_First.Instance.camera_Transform.position = new Vector3(x, getComponent_First.Instance.player_Transform.position.y+3.059124f, -30);
        }
        else
        {
            getComponent_First.Instance.camera_Transform.position = new Vector3(x, startPos.y, -30);
        }
        if(getComponent_First.Instance.camera_Transform.position.y>=0.89f)
        {
            getComponent_First.Instance.camera_Transform.position = new Vector3(getComponent_First.Instance.camera_Transform.position.x, 0.89f, getComponent_First.Instance.camera_Transform.position.z);
        }
        else if(getComponent_First.Instance.camera_Transform.position.x >= 168.4889f)
        {
            getComponent_First.Instance.camera_Transform.position = new Vector3(168.4889f, getComponent_First.Instance.camera_Transform.position.y, getComponent_First.Instance.camera_Transform.position.z);
        }
    }
    private void inRoom()
    {
        if (isCome == false&&isRead==false&&isUse==false)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 2.282839f;
            gameObject.GetComponent<Transform>().position = getComponent_First.Instance.player_Transform.position + roomOffset;
            if (gameObject.GetComponent<Transform>().position.x<= -35.87f)
            {
                gameObject.GetComponent<Transform>().position = new Vector3(-35.87f, (getComponent_First.Instance.player_Transform.position + roomOffset).y, (getComponent_First.Instance.player_Transform.position + roomOffset).z);
            }
            else if (gameObject.GetComponent<Transform>().position.x >= -29.7f)
            {
                gameObject.GetComponent<Transform>().position = new Vector3(-29.7f, (getComponent_First.Instance.player_Transform.position + roomOffset).y, (getComponent_First.Instance.player_Transform.position + roomOffset).z);
            }
            else if (gameObject.GetComponent<Transform>().position.y >= 1.71f)
            {
                gameObject.GetComponent<Transform>().position = new Vector3((getComponent_First.Instance.player_Transform.position + roomOffset).x, 1.71f, (getComponent_First.Instance.player_Transform.position + roomOffset).z);
            }
        }
    }
}
