using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getComponent_First : MonoBehaviour,IgetComponent
{
    public Transform player_Transform;
    public Transform phantom_Transform;
    public Transform camera_Transform;

    public Animator player_Animator;
    public Rigidbody2D player_Rigibody2D;
    public BoxCollider2D player_BoxCollider2D;
    public SpriteRenderer player_SpriteRenderer;
    public Text text_Text;

    public playerController player_playerController;
    public SpriteRenderer phantom_SpriteRenderer;
    public PlayerTimeBack player_PlayerTimeBack;
    public cameraMove camera1;
    public phantom phantom1;
    public brickUpAndDown brickUpAndDown1;
    public BGColor BG;

    public static getComponent_First Instance;
    private void OnEnable()
    {
        getCom();
        Instance = this;
    }
    public void getCom()
    {
        player_Transform = getObject_First.Instance.player.GetComponent<Transform>();
        player_Animator = getObject_First.Instance.player.GetComponent<Animator>();
        player_Rigibody2D = getObject_First.Instance.player.GetComponent<Rigidbody2D>();
        player_BoxCollider2D = getObject_First.Instance.player.GetComponent<BoxCollider2D>();
        brickUpAndDown1 = getObject_First.Instance.object_BrickUpAndDown1.GetComponent<brickUpAndDown>();
        player_playerController = getObject_First.Instance.player.GetComponent<playerController>();
        player_SpriteRenderer = getObject_First.Instance.player.GetComponent<SpriteRenderer>();
        phantom_Transform = getObject_First.Instance.object_Phantom.GetComponent<Transform>();
        phantom_SpriteRenderer = getObject_First.Instance.object_Phantom.GetComponent<SpriteRenderer>();
        camera_Transform = getObject_First.Instance.object_Camera.GetComponent<Transform>();
        camera1 = getObject_First.Instance.object_Camera.GetComponent<cameraMove>();
        player_PlayerTimeBack = getObject_First.Instance.player.GetComponent<PlayerTimeBack>();
        phantom1 = getObject_First.Instance.object_Phantom.GetComponent<phantom>();
        text_Text = getObject_First.Instance.object_Text.GetComponent<Text>();
    }
}
