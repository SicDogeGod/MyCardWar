using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData : MonoBehaviour
{
    string[] playDatasKey = new string[] 
    {
        //用户信息
        "user_count",
        "user_password",

        //角色信息
        "play_level",
        "play_money",
        
        //游戏进程
            //玩家角色解锁
        "character_unlock01",

        //游戏进程
            //玩家道具解锁
        "item_unlock01"
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetAllData()
    {
        for (int i=0; i<playDatasKey.Length; i++)
        {

            PlayerPrefs.SetString(playDatasKey[i], "0");
        }
    }
    void OnCreaterCounter()
    {
        ResetAllData();
    }


}
