using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFactoryB : MonoBehaviour
{
    public GameObject open;
    public GameObject close;
    public LayerMask bomb_LayerMask;
    public LayerMask box_LayerMask;
    private bool isCreate = true;
    private void Update()
    {
        create();
    }
    private void create()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == false&&isCreate&&Input.GetKey(KeyCode.RightArrow)==false)
        {
            isCreate = false;
            StartCoroutine("createEnemy");
        }
    }
    private IEnumerator createEnemy()
    {
        if (Physics2D.Raycast(gameObject.GetComponent<Transform>().position + new Vector3(0, -0.65f, 0), Vector2.left, 20.15f, bomb_LayerMask) == false && Physics2D.Raycast(gameObject.GetComponent<Transform>().position + new Vector3(0, -0.65f, 0), Vector2.left, 20.15f, box_LayerMask) == false)
        {
            open.SetActive(true);
            close.SetActive(false);
            GameObject.Instantiate(Resources.Load<GameObject>("bomb/BombB"), gameObject.GetComponent<Transform>().position + new Vector3(-2.15f, 0, -1.3f), Quaternion.identity, gameObject.GetComponent<Transform>());
        }
        yield return new WaitForSeconds(1);
        open.SetActive(false);
        close.SetActive(true);
        isCreate = true;
    }
}
