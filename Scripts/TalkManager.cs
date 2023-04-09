using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

        PortData.Add(1000, PortArr[0]);
        PortData.Add(1000 + 1, PortArr[1]);
        PortData.Add(1000 + 2, PortArr[2]);
        PortData.Add(1000 + 3, PortArr[3]);
    }
    public string GetTalk(int id, int talkIndex)
    {
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
