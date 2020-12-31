using UnityEngine;

public class Switch2 : MonoBehaviour
{
    public bool SwitchOn = false;
    public GameObject LP;
    public GameObject tip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tip.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchOn = !SwitchOn;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tip.SetActive(false);
        }
    }
}
