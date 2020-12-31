using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour
{
    public comeInCheckPoint open;
    private int i = 0;
    private bool isStart = false;
    private bool isChange = false;
    List<Sprite> m_Sprite = new List<Sprite>();
    private void Awake()
    {
        getValue();
    }
    private void Update()
    {
        getIsChange();
        startCha();
    }
    private void startCha()
    {
        if(isStart)
        {
            isStart = false;
            InvokeRepeating("startChange", 0.5f, 0.5f);
        }
    }
    private void getValue()
    {
        for (int i = 2; i < 8; i++)
        {
            Sprite a = Resources.Load<Sprite>("9836/" + i);
            m_Sprite.Add(a);
        }
    }
    private void startChange()
    {
        if(isChange)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_Sprite[i];
            i++;
            if (i >= 6)
            {
                i = 5;
                CancelInvoke("startChange");
            }
        }
    }
    private void getIsChange()
    {
        if (getComponent_First.Instance.BG.isMove == false && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isStart = true;
        }
        if (getComponent_First.Instance.BG.isMove==false&&Input.GetKey(KeyCode.LeftArrow))
        {
            isChange = true;
        }
        else
        {
            isChange = false;
        }
        if(gameObject.GetComponent<SpriteRenderer>().sprite == m_Sprite[5])
        {
            open.isOpen = true;
        }
    }
}
