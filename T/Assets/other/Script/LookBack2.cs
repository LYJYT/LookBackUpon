using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookBack2 : MonoBehaviour
{
    public bool lookBack;
    public Transform go;
    public CinemachineVirtualCamera playercinema;

    private void Start()
    {
        GameObject go = GameObject.Find("Phantoms");
    }

    private void Update()
    {
    }

    IEnumerator LookBackPhan()
    {
        List<Transform> item = new List<Transform>();
        foreach (Transform child in go.transform)
        {
            item.Add(child);
        }
        for (int i = 0; i < item.Count; i++)
        {
            item[i].Find("CM vcam1 (1)").gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        InvokeRepeating("OpenPlayer",2 , 0);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine("LookBackPhan");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            InvokeRepeating("ClosePlayer", 2, 0);
        }
    }

    void ClosePlayer()
    {
        playercinema.gameObject.SetActive(false);
    }
    void OpenPlayer() 
    {
        playercinema.gameObject.SetActive(true);
        Destroy(gameObject);
    }

}
