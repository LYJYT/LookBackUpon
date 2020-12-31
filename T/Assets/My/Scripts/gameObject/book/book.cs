using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    private bool isRead = false;
    private void Start()
    {
        iniBook();
    }
    private void Update()
    {
        readBook();
    }
    private void iniBook()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name=="Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isRead = true;
                getComponent_First.Instance.camera1.isRead = isRead;
                getComponent_First.Instance.camera_Transform.position = new Vector3(-29.7f, getComponent_First.Instance.camera_Transform.position.y, -30);
                getComponent_First.Instance.BG.changeColor(true);
                getComponent_First.Instance.BG.isControl = false;
            }
        }
    }
    private void readBook()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isRead = false;
            getComponent_First.Instance.camera1.isRead = isRead;
            getComponent_First.Instance.BG.changeColor(false);
            getComponent_First.Instance.BG.isControl = true;
        }
        if(isRead)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
