using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenData();
    }
    void GenData()
    {
        questList.Add(10, new QuestData("마을 사람들과 대화하기", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("루도의 동전 찾기", new int[] { 5000, 2000 }));
        questList.Add(30, new QuestData("퀘스트 올 클리어!", new int[] { 0 }));
    }
    public int GenQTalkIndex(int id)
    {
        return questId + questActionIndex;
    }
    //대화 종료시 호출하는 함수
    public string checkQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            //다음 화자로 넘김
            questActionIndex++;
        }
        controlObject();
        //모든 화자가 말하면
        if (questActionIndex == questList[questId].npcId.Length)
        {
            //다음 퀘로 넘김
            nextQuest();
        }
        //퀘스트 이름 반환
        return questList[questId].questName;
    }
    public string checkQuest()
    {
        return questList[questId].questName;
    }
    void nextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
    public void controlObject()
    {
        switch(questId)
        {
            case 10:
                if(questActionIndex == 2)
                {
                    questObject[0].SetActive(true);
                }
                break;
            case 20:
                if (questActionIndex == 0)
                    questObject[0].SetActive(true);
                else if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
