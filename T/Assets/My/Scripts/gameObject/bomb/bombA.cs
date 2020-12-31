using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombA : MonoBehaviour
{
    private bool isjump = true;
    private void Update()
    {
        dead();
    }
    private void dead()
    {
        
        if(gameObject.GetComponent<bomb>().isDead == true && isjump)
        {
            isjump = false;
            getComponent_First.Instance.player_Rigibody2D.velocity = new Vector2(0, 6);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("destoryMyself");
        }
    }
    private IEnumerator destoryMyself()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}
