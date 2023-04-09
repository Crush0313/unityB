using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject ui;
    public Image Portimg;
    public Text text;
    public bool isAction;
    public int talkIndex;
    public void WriteText(GameObject obj)
    {
        ObjectData objData = obj.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNPC);
        ui.SetActive(isAction);
    }
    void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if(talkData == null)
        {
            talkIndex = 0;
            isAction = false;
            return;
        }
        if(isNPC)
        {
            text.text = talkData.Split(':')[0];
            Portimg.sprite = talkManager.getPort(id, int.Parse(talkData.Split(':')[1]));
            Portimg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            text.text = talkData;
            Portimg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
}
