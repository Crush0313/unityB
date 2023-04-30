using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator ui;
    public Image Portimg;
    public Sprite PrevPort;
    public Animator PortAnim;
    public Text Qtext;
    public TypeEffect talk;
    public GameObject menuSet;
    public GameObject player;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Start()
    {
        Load();
        Qtext.text = questManager.checkQuest();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SubMenuActive();
        }
    }
    public void SubMenuActive()
    {
        if (menuSet.activeSelf)
            menuSet.SetActive(false);
        else
            menuSet.SetActive(true);
    }
    public void WriteText(GameObject obj)
    {
        ObjectData objData = obj.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNPC);
        ui.SetBool("IsShow", isAction);
    }
    void Talk(int id, bool isNPC)
    {

        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GenQTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        if (talkData == null)
        {
            talkIndex = 0;
            isAction = false;
            Qtext.text = questManager.checkQuest(id);
            return;
        }
        if(isNPC)
        {
            talk.SetMsg(talkData.Split(':')[0]);
            Portimg.sprite = talkManager.getPort(id, int.Parse(talkData.Split(':')[1]));
            Portimg.color = new Color(1, 1, 1, 1);
            if(PrevPort != Portimg.sprite)
            {
                PortAnim.SetTrigger("DoEffect");
                PrevPort = Portimg.sprite;
            }
        }
        else
        {
            talk.SetMsg(talkData);
            Portimg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("Qid", questManager.questId);
        PlayerPrefs.SetInt("Qindex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }
    public void Load()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int Qid = PlayerPrefs.GetInt("Qid");
        int Qindex = PlayerPrefs.GetInt("Qindex");

        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = Qid;
        questManager.questActionIndex = Qindex;
        questManager.controlObject();

    }
    public void GameExit()
    {
        Application.Quit();
    }
}
