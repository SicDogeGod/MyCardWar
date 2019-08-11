using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
     /****************************************************************
     * 注册需要在场景开始时加载的脚本
     ****************************************************************/
    public PlayData playData;
    public Player player;
    public PlayerInfoListCon playerInfoListCon;

    public Hashtable startScriptCheck = new Hashtable();

    private void Start()
    {
        ScriptCheck();
        AllCheck();
    }

    void ScriptCheck()
    {
        startScriptCheck.Add("playData",false);
        startScriptCheck.Add("player", false);
        startScriptCheck.Add("playerInfoListCon", false);
    }

    void AllCheck()
    {
        if (!(bool)startScriptCheck["playData"])
        {
            playData.PlayDataStart();
            return ;
        }
        if (!(bool)startScriptCheck["player"])
        {
            player.StartCheckData();
            return;
        }
        if (!(bool)startScriptCheck["playerInfoListCon"])
        {
            playerInfoListCon.StartDataCheck();
            return;
        }
        Debug.Log("加载完毕");
    }

    public void ChangeScriptCheck(string keystr,bool values)
    {
        startScriptCheck[keystr] = values;
        Invoke("AllCheck",0.1f);
    }
}
