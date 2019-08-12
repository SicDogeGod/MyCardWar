using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoListCon : MonoBehaviour
{
    public Player player;
    public MsgControl msgControl;
    public GameControl gameControl;

    public Text playerName;
    public Text playerLevel;
    public Text playerLifeText;

    public Image playerLifeBar;
    public Image playerTimeBar;

    float playerRecentLife;
    float playerMaxLife;
    float playerLifePercent;

    float playerTimeRecent = 0f;
    float playerTimeMax = 1f;
    public void StartDataCheck()
    {
        playerName.text = player.GetPlayerName() ;
        playerLevel.text = player.GetPlayerLevel().ToString();
        playerRecentLife = player.GetPlayerLife();
        playerMaxLife = player.GetPlayerLife();
        playerLifeText.text = playerRecentLife.ToString();
        Debug.Log("--玩家角色信息面板加载完毕");
        gameControl.ChangeScriptCheck("playerInfoListCon", true);
    }

    public void UpdateLifeBar(float changenumber)
    {
        if (changenumber>0)
        {
            msgControl.SendFloatMsg("+" + changenumber, Color.green);
        }
        else
        {
            msgControl.SendFloatMsg(changenumber.ToString(),Color.red);
        }
        playerRecentLife += changenumber;
        playerLifeText.text = playerRecentLife.ToString();
        playerLifePercent = playerRecentLife / playerMaxLife;
        playerLifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 100 * playerLifePercent);
    } 
    
}
