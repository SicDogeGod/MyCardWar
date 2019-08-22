using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControl : MonoBehaviour
{
    bool canStartBattle = false;

    public GameData gameData;
    public GameControl gameControl;

    public Character character;
    float player_recentlife;
    public Monster monster;
    float monster_recentlife;

    public void PerLoad()
    {
        OnBattleStart();
    }

    void OnBattleStart()
    {
        Debug.Log("Start load battle.");

        character = gameData.characters[1];
        Player player = new Player(PlayerPrefs.GetString("play_name"),PlayerPrefs.GetInt("play_level"));
        player.SetAttriblity(character);
        player_recentlife = player.MaxLife;

        monster = gameData.monsters[1];
        Enemy enemy = new Enemy(monster);
        monster_recentlife = enemy.MaxLife;

        Debug.LogWarning("player_name->"+player.Name);
        Debug.LogWarning("player_level->" + player.Level);
        Debug.LogWarning("Monster_name->" + enemy.Name);
        Debug.LogWarning("Monster_name->" + enemy.Level);

        Debug.Log("End load battle.");
        gameControl.PerLoadAssets("battleControl");

        
    }

    void OnBattleIn()
    {
        do {

        } while (player_recentlife<0 || monster_recentlife<0);
    }

    void OnBattleFinish()
    {

    }

    /*
     * ***********************************************************************
     */
     public void SetCanBattle()
    {
        if (canStartBattle)
        {
            canStartBattle = false;
        }
        else
        {
            canStartBattle = true;
        }
    }
}


