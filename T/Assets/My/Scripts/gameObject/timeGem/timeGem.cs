using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeGem : MonoBehaviour
{
    private bool isUse = false;
    private void Start()
    {
        iniTimeGem();
    }
    private void Update()
    {
        useGem();
    }
    private void iniTimeGem()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isUse = true;
                getComponent_First.Instance.camera1.isUse = isUse;
                getComponent_First.Instance.camera_Transform.position = new Vector3(-29.7f, getComponent_First.Instance.camera_Transform.position.y, -30);
                getComponent_First.Instance.BG.changeColor(true);
                getComponent_First.Instance.BG.isControl = false;
            }
        }
    }
    private void useGem()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isUse = false;
            getComponent_First.Instance.camera1.isUse = isUse;
            getComponent_First.Instance.BG.changeColor(false);
            getComponent_First.Instance.BG.isControl = true;
        }
        if (isUse)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
