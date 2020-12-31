using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public bool canUse;
    private void Update()
    {
        canUse = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2>().canUseKey;
    }

    public void Use()
    {
        if (canUse)
        {
            GameObject.Find("Door1/Door").GetComponent<Animator>().SetBool("switch", true);
            Destroy(gameObject);
        }
    }
}
