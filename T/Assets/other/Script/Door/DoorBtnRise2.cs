using UnityEngine;

public class DoorBtnRise2 : MonoBehaviour
{
    Animator anim;
    public GameObject btn;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (btn.GetComponent<DoorButton2>().on == 1)
        {
            anim.speed = 0.5f;
            InvokeRepeating("StopRise",0.9f, 0);   //升起X秒后停止
        }
        else
        {
            anim.speed = 0f;
        }
    }

    void StopRise()
    {
        btn.GetComponent<DoorButton2>().on --;
    }
}
