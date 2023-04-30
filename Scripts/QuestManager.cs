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
        questList.Add(10, new QuestData("���� ������ ��ȭ�ϱ�", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("�絵�� ���� ã��", new int[] { 5000, 2000 }));
        questList.Add(30, new QuestData("����Ʈ �� Ŭ����!", new int[] { 0 }));
    }
    public int GenQTalkIndex(int id)
    {
        return questId + questActionIndex;
    }
    //��ȭ ����� ȣ���ϴ� �Լ�
    public string checkQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            //���� ȭ�ڷ� �ѱ�
            questActionIndex++;
        }
        controlObject();
        //��� ȭ�ڰ� ���ϸ�
        if (questActionIndex == questList[questId].npcId.Length)
        {
            //���� ���� �ѱ�
            nextQuest();
        }
        //����Ʈ �̸� ��ȯ
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
