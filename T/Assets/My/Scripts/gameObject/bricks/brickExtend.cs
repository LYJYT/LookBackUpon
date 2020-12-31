using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickExtend : MonoBehaviour
{
    public float variation = 0;
    public virtual void extend()
    {
        variation += 0.0005f;
    }
}
