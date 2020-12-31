using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public door door;
    public bool isHaveKey = false;
    private void Update()
    {
        stage(isHaveKey);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if(getComponent_First.Instance.BG.isMove)
            {
                isHaveKey = true;
            }
        }
    }
    public void resetDoorAndKey()
    {
        door.resetDoor();
        gameObject.SetActive(true);
        isHaveKey = false;
    }
    private void stage(bool have)
    {
        door.isHaveKey = have;
        gameObject.GetComponent<SpriteRenderer>().enabled = !have;
    }
}
