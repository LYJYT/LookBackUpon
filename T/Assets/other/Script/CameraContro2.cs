using Cinemachine;
using UnityEngine;

public class CameraContro2 : MonoBehaviour
{
    public CinemachineVirtualCamera cinema;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (cinema.m_Lens.OrthographicSize < 6.4f)
            {
                cinema.m_Lens.OrthographicSize += 0.01f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Reduce();
        }
    }

    void Reduce()
    {
        for (float i = cinema.m_Lens.OrthographicSize; i > 6f; i -= 0.001f)
        {
            cinema.m_Lens.OrthographicSize = i;
        }
    }
}
