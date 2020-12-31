using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickExtend_UAndD : brickExtend
{
    void Update()
    {
        extend();
    }
    public override void extend()
    {
        base.extend();
        gameObject.GetComponent<Transform>().localScale = new Vector3(0, base.variation, 0);
    }
}
