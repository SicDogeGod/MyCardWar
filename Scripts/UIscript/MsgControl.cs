using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgControl : MonoBehaviour
{
    public Text[] msgbox_text;

    public GameObject floattext_point;
    public GameObject floattext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string SystemTime()
    {
        string str = "";
        int hour = DateTime.Now.Hour;
        int minite = DateTime.Now.Minute;
        int second = DateTime.Now.Second;
        str = String.Format("{0}:{1}:{2}    ",hour,minite,second);
        return str;
    }

    public void SendMsgBox(string text)
    {
        for (int i = 4;i>0;i--)
        {
            msgbox_text[i].text = msgbox_text[i - 1].text;
        }
        msgbox_text[0].text = SystemTime() + text;
    }
    public void SendFloatMsg(string str , Color colors)
    {
        GameObject gameObject = GameObject.Instantiate(floattext,floattext_point.transform);
        gameObject.GetComponent<FloatText>().SetFloatText(str,colors);
    }
}
