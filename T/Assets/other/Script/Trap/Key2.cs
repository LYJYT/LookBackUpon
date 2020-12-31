using UnityEngine;

public class Key2 : MonoBehaviour
{
    Rigidbody2D rig;
    public GameObject trapCon;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TrapController2 tc = trapCon.GetComponent<TrapController2>();
        if (collision.transform.tag == "Player")
        {
            tc.canChange = true;
            gameObject.SetActive(false);
        }
    }
}
