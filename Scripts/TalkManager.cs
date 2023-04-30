using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> PortData;
    public Sprite[] PortArr;

    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        PortData = new Dictionary<int, Sprite>();

        generateData();

    }

    void generateData()
    {
        talkData.Add(100, new string[] { "������ ���� �������ڴ�." });
        talkData.Add(1000, new string[] {"�ȳ��ϽŰ�:1", "������ �絵�� ���� ȯ���Ͽ� �����̿�.:0" });
        talkData.Add(2000, new string[] { "�ȳ��ϽŰ�:1", "������ �絵�� ���� ȯ���Ͽ� �����̿�.:0" });

        PortData.Add(1000, PortArr[0]);
        PortData.Add(1000 + 1, PortArr[1]);
        PortData.Add(1000 + 2, PortArr[2]);
        PortData.Add(1000 + 3, PortArr[3]);

        PortData.Add(2000, PortArr[4]);
        PortData.Add(2000 + 1, PortArr[5]);
        PortData.Add(2000 + 2, PortArr[6]);
        PortData.Add(2000 + 3, PortArr[7]);

        //����Ʈ ��ȭ
        talkData.Add(1000 + 10, new string[] { "�����:1",
               "�� �������� ���� ������ �־�:0",
                "���� ���� �絵���� �� ��:1"});
        talkData.Add(2000 + 11, new string[] { "�ҹ��� ��� �Գ�:1",
               "�Ҿ���� �� ������ ã���ָ� ��������:0",
                "���� Ǯ �ӿ� ���� �ž�:1"});

        talkData.Add(5000 + 20, new string[] { "������ ã�Ҵ�",});
        talkData.Add(2000 + 21, new string[] { "ã���༭ ����:2",});
    }
    public string GetTalk(int id, int talkIndex)
    {
        //�ش� ����Ʈ ���� �� ��簡 ���� ��
        if (!talkData.ContainsKey(id)){
            //����Ʈ �� ó�� ��縶�� ���� ��
            if (!talkData.ContainsKey(id - id % 10))
            {
                //2031 -> 2031 - 31 = 2000
                //�⺻ ��� ������
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                //2031 -> 2031 - 1 = 2030
                //����Ʈ �� ó�� ��ȭ ������
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length)
            return null;   
        else
            return talkData[id][talkIndex];
    }
    public Sprite getPort(int id, int PortId)
    {
        return PortData[id + PortId];
    }
}
