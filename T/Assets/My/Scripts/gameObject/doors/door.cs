using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject door_Close;
    public bool isHaveKey = false;
    public bool isOpen = false;
    private void Awake()
    {
        getValue();
    }
    private void getValue()
    {
        door_Close = gameObject.GetComponent<Transform>().Find("door_Close").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (isHaveKey)
            {
                isOpen = true;
                door_Close.SetActive(!isOpen);
            }
        }
    }
    public void resetDoor()
    {
        isHaveKey = false;
        door_Close.SetActive(true);
    }
}
