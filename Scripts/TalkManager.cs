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
        talkData.Add(100, new string[] { "냄새가 나는 나무상자다." });
        talkData.Add(1000, new string[] {"안녕하신가:1", "조선에 당도한 것을 환영하오 낯선이여.:0" });
        talkData.Add(2000, new string[] { "안녕하신가:1", "조선에 당도한 것을 환영하오 낯선이여.:0" });

        PortData.Add(1000, PortArr[0]);
        PortData.Add(1000 + 1, PortArr[1]);
        PortData.Add(1000 + 2, PortArr[2]);
        PortData.Add(1000 + 3, PortArr[3]);

        PortData.Add(2000, PortArr[4]);
        PortData.Add(2000 + 1, PortArr[5]);
        PortData.Add(2000 + 2, PortArr[6]);
        PortData.Add(2000 + 3, PortArr[7]);

        //퀘스트 대화
        talkData.Add(1000 + 10, new string[] { "어서오슈:1",
               "이 마을에는 슬픈 전설이 있어:0",
                "마을 동쪽 루도에게 가 봐:1"});
        talkData.Add(2000 + 11, new string[] { "소문을 듣고 왔나:1",
               "잃어버린 내 동전을 찾아주면 말해주지:0",
                "마을 풀 속에 있을 거야:1"});

        talkData.Add(5000 + 20, new string[] { "동전을 찾았다",});
        talkData.Add(2000 + 21, new string[] { "찾아줘서 고맙네:2",});
    }
    public string GetTalk(int id, int talkIndex)
    {
        //해당 퀘스트 진행 중 대사가 없을 때
        if (!talkData.ContainsKey(id)){
            //퀘스트 맨 처음 대사마저 없을 때
            if (!talkData.ContainsKey(id - id % 10))
            {
                //2031 -> 2031 - 31 = 2000
                //기본 대사 가져옴
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                //2031 -> 2031 - 1 = 2030
                //퀘스트 맨 처음 대화 가져옴
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
