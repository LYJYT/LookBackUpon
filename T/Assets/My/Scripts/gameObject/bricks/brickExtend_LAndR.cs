using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickExtend_LAndR : brickExtend
{
    void Update()
    {
        extend();
    }
    public override void extend()
    {
        base.extend();
        gameObject.GetComponent<Transform>().localScale = new Vector3(base.variation, 0, 0);
    }
}
