using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleItem : MonoBehaviour
{
    public void Use()
    {
        Destroy(gameObject);
    }
}
