using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*********************************************************************
     * 类属性定义 *
     *********************************************************************/
    int playUid;
    int playLevel;
    float playAttack;
    float playDefend;
    float playLife;
    float playSpeed;
    float playCritical;
    float playParry;
    int playInflexible;
    int playKeen;
    int playPower;
    string playName;

    /*********************************************************************
     * 游戏工程内部定义 *
     *********************************************************************/
    public PlayData playDatas;
    public GameControl gameControl;
    public PlayerInfoListCon playerInfoListCon;

    public int characterIndex = 1;

    float RecentTime = 0f;
    bool CanAttack = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCheckData()
    {
        playUid = playDatas.GetCharacter(characterIndex).index;
        playLevel = playDatas.GetCharacter(characterIndex).level;
        playAttack = playDatas.GetCharacter(characterIndex).attack;
        playDefend = playDatas.GetCharacter(characterIndex).defend;
        playLife = playDatas.GetCharacter(characterIndex).life;
        playSpeed = playDatas.GetCharacter(characterIndex).speed;
        playCritical = playDatas.GetCharacter(characterIndex).critical;
        playParry = playDatas.GetCharacter(characterIndex).parry;
        playInflexible = playDatas.GetCharacter(characterIndex).inflexible;
        playKeen = playDatas.GetCharacter(characterIndex).keen;
        playPower = playDatas.GetCharacter(characterIndex).power;
        playName = playDatas.GetCharacter(characterIndex).name;
        Debug.Log("--玩家角色信息加载完毕");
        gameControl.ChangeScriptCheck("player",true);
        
    }

    public void ChangeBattleStatu()
    {
        if (CanAttack)
        {
            CanAttack = false;
        }
        else
        {
            CanAttack = true;
        }
    }

    public string GetPlayerName()
    {
        return playName;
    }
    public int GetPlayerLevel()
    {
        return playLevel;
    }
    public float GetPlayerLife()
    {
        return playLife;
    }
    
}
