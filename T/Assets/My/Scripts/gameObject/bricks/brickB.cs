using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickB : MonoBehaviour
{
    public LayerMask player_LayerMask;
    private void Update()
    {
        if(Physics2D.Raycast(gameObject.GetComponent<BoxCollider2D>().bounds.center,Vector2.up, gameObject.GetComponent<BoxCollider2D>().bounds.extents.y+0.1f,player_LayerMask))
        {
            StartCoroutine("destroy");
        }
    }
    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}
