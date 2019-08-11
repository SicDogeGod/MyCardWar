using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoListCon : MonoBehaviour
{
    public Player player;
    public GameControl gameControl;

    public Text playerName;
    public Text playerLevel;

    public Image playerLifeBar;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDataCheck()
    {
        playerName.text = player.GetPlayerName() ;
        playerLevel.text = player.GetPlayerLevel().ToString();
        Debug.Log("--玩家角色信息面板加载完毕");
        gameControl.ChangeScriptCheck("playerInfoListCon", true);
    }
}
