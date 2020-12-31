using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickC : MonoBehaviour
{
    private void Start()
    {
        iniActive();
    }
    private void iniActive()
    {
        StartCoroutine("changeActive");
    }
    private IEnumerator changeActive()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(2);
            gameObject.SetActive(true);
        }
    }
}
