using UnityEngine;

public class Key2Item : MonoBehaviour
{
    public bool canUse;

    private void Update()
    {
        canUse = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2>().canUseKey2;
    }

    public void Use()
    {
        if (canUse)
        {
            GameObject.Find("Trap/TrapCon").GetComponent<Animator>().SetBool("usekey", true);
            Destroy(gameObject);
        }
    }
}
