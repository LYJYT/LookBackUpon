using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getObject_First : MonoBehaviour,IgetObject
{
    public GameObject player;
    public GameObject object_BrickUpAndDown1;
    public GameObject object_Phantom;
    public GameObject object_Camera;
    public GameObject object_Text;



    public static getObject_First Instance;
    private void Awake()
    {
        getObject();
        Instance = this;
    }
    public void getObject()
    {
        player = GameObject.Find("Player");
        object_BrickUpAndDown1 = GameObject.Find("brickUpAndDown1");
        object_Phantom = GameObject.Find("Phantom");
        object_Camera = GameObject.Find("Main Camera");
        object_Text = GameObject.Find("Text");
    }
}
