using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phantom : MonoBehaviour
{
    public bool isPhantom = false;
    private bool isSetValue = true;
    private int i = 0;
    private List<PlayerObjectStage> phantom1 = new List<PlayerObjectStage>();
    private List<PlayerObjectStage> phantom2 = new List<PlayerObjectStage>();
    private void Update()
    {
        saveData();
        loadData();
    }
    private void saveData()
    {
        if(getComponent_First.Instance.camera_Transform.position.x>= -5.2f)
        {
            PlayerObjectStage stageData = new PlayerObjectStage();
            stageData.Position = getComponent_First.Instance.player_Transform.position;
            stageData.isFacingRight = getComponent_First.Instance.player_playerController.isFacingRight;
            stageData.Sprite = getComponent_First.Instance.player_SpriteRenderer.sprite;
            phantom1.Add(stageData);
        }
    }
    private void loadData()
    {
        if(isPhantom)
        {
            if(isSetValue)
            {
                for (int i = 10; i < phantom1.Count; i++)
                {
                    phantom2.Add(phantom1[i]);
                }
                phantom1.Clear();
                isSetValue = false;
            }
            gameObject.GetComponent<Transform>().position = phantom2[i].Position;
            gameObject.GetComponent<SpriteRenderer>().sprite = phantom2[i].Sprite;
            if (phantom2[i].isFacingRight)
            {
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            }
            i++;
            if(i>=phantom2.Count)
            {
                i = 0;
                isPhantom = false;
                isSetValue = true;
                phantom2.Clear();
            }
        }
    }
}
