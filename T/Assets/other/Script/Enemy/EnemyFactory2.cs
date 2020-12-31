using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory2 : MonoBehaviour
{
    Animator anim;
    public Collider2D first;
    public GameObject enemy;
    public GameObject enemyCount;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("switch", true);
            first.enabled = false;
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            anim.SetBool("switch", true);
        }
    }

    public void ProductEnemy()
    {
        GameObject a = Instantiate(enemy,enemyCount.transform.position, Quaternion.identity);
        a.transform.parent = enemyCount.transform;
        anim.SetBool("switch", false);
    }  

}
