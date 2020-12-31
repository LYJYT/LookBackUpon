using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour
{
    public float totalTime;
    public float _timeScale;
    public Text timeUI;
    public GameObject to;
    public GameObject timebackEffect;
    public GameObject player;
    public bool isAdopt; //到达关底

    private void Start()
    {
        to.gameObject.SetActive(false);
        ConverToTimeStr((int)totalTime);
    }

    void Update()
    {
        TimeOver();
        Adopt();
        ChangeTimeScale();
    }

    //改变时间速度
    void ChangeTimeScale()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            timebackEffect.SetActive(true);
            Time.timeScale = _timeScale;
        }
        else
        {
            timebackEffect.SetActive(false);
            Time.timeScale = 1f;
        }

    }


    //倒计时
    void TimeOver()
    {
        totalTime -= Time.deltaTime;
        timeUI.text = ConverToTimeStr((int)totalTime);
        if (totalTime <= 0 && !isAdopt)
        {
            to.gameObject.SetActive(true);
            player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            InvokeRepeating("ReLoad", 3f, 0f);
        }
    }

    void ReLoad()
    {
        SceneManager.LoadScene("SampleScene");
    }

    string ConverToTimeStr(int sec)
    {
        int m = sec/ 60;
        int s = sec % 60;
        return string.Format("{0}:{1}",m, s);
    }

    //到达关底
    void Adopt()
    {
        if (isAdopt)
        {
            Debug.Log("Adopt");
        }
    }

}
