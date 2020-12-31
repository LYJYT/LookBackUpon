using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CB : MonoBehaviour
{
    public float speed = 6;

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.transform.position = new Vector2(collision.transform.position.x + speed * Time.deltaTime , collision.transform.position.y);
    }
}
