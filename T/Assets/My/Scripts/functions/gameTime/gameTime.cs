using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTime : MonoBehaviour
{
    public int time = 0;
    public static gameTime Instance;
    private void Awake()
    {
        Instance = this;
        StartCoroutine("calcTime");
    }
    private IEnumerator calcTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
}
