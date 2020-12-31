using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGColor : MonoBehaviour
{
    public bool isMove = true;
    public bool isControl = true;
    private void Update()
    {
        changeBGColor();
    }
    private void changeBGColor()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl)&&isControl)
        {
            if(gameObject.GetComponent<Animator>().GetBool("isTimeBack")==false)
            {
                changeColor(true);
            }
            else if(gameObject.GetComponent<Animator>().GetBool("isTimeBack") == true)
            {
                changeColor(false);
            }
        }
    }
    public void changeColor(bool a)
    {
        gameObject.GetComponent<Animator>().SetBool("isTimeBack", a);
        isMove = !a;
    }
}
