using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int charPerSec;
    string targetMsg;
    Text msgText;
    int index;
    public GameObject endCursor;
    AudioSource audioSource;
    public bool isAnim;

    public void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            effectEnd();
        }
        else
        {

            targetMsg = msg;
            effectStart();
        }
    }
    void effectStart()
    {
        msgText.text = "";
        index = 0;
        endCursor.SetActive(false);
        isAnim = true;

        Invoke("effecting", 1 / charPerSec);
    }
    void effecting()
    {
        if(msgText.text == targetMsg)
        {
            effectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        if(targetMsg[index] != ' ' || targetMsg[index] != '.')
        {
            audioSource.Play();
        }
        index++;

        Invoke("effecting", 1.0f / charPerSec);
    }
    void effectEnd()
    {
        isAnim = false;
        endCursor.SetActive(true);
    }
}
