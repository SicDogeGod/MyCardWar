using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControl : MonoBehaviour
{
    bool canStartBattle = false;

    public GameData gameData;
    public MsgControl msgControl;
    public GameControl gameControl;
    public MonsterLifeBar monster_lifeBar;
    public PlayerInfoList player_infoList;


    public Character character;
    public Player player;
    float player_recentlife;
    float player_speed;
    public Monster monster;
    public Enemy enemy;
    float monster_recentlife;
    float monster_speed;

    public void PerLoad()
    {
        OnBattleStart();
    }

    void OnBattleStart()
    {
        Debug.Log("Start load battle.");

        character = gameData.characters[1];
        player = new Player(PlayerPrefs.GetString("play_name"),PlayerPrefs.GetInt("play_level"));
        player.SetAttriblity(character);
        player_recentlife = player.MaxLife;
        player_speed = 0f;
        SetPlayerLifeBar();

        monster = gameData.monsters[1];
        enemy = new Enemy(monster);
        monster_recentlife = enemy.MaxLife;
        SetEnemyLifeBar();
        monster_speed = 0f;

        Debug.Log("End load battle.");
        gameControl.PerLoadAssets("battleControl");

        OnBattleIn();
    }

    private void FixedUpdate()
    {
        if (canStartBattle)
        {
            player_speed += Time.deltaTime;
            monster_speed += Time.deltaTime;
        }
    }

    void OnBattleIn()
    {
        Debug.Log("Call OnBattleIn");

        PlayerAttack();
        EnemyAttack();

        if (player_recentlife <=0 || monster_recentlife <= 0)
        {
            OnBattleFinish();
        }
        else
        {
            Invoke("OnBattleIn",0.1f);
        }
    }

    void OnBattleFinish()
    {
        Debug.Log("Game Over");
    }
    /*
     * ***********************************************************************
     */
     void PlayerAttack()
    {
        if (player_speed >= player.Speed)
        {
            player_speed = 0f;
            float getDamage = enemy.EnemyGetDamage(player.Attack, player.Critical_rate);
            monster_recentlife -= getDamage;
            SetEnemyLifeBar();
            msgControl.SendFloatMsg("-" + getDamage.ToString(),Color.yellow);
        }
     }
    void SetPlayerLifeBar()
    {
        player_infoList.SetTextValue(player.Name, player.Level.ToString());
        player_infoList.SetLifeBarValue(player.MaxLife,player_recentlife);
    }

     void EnemyAttack()
    {
        if (monster_speed >= enemy.Speed)
        {
            monster_speed = 0f;
            float getDamage = player.PlayerGetDamage(enemy.Attack);
            player_recentlife -= getDamage;
            msgControl.SendFloatMsg("-"+getDamage.ToString(), Color.red);
            SetPlayerLifeBar();
        }
    }
     void SetEnemyLifeBar()
    {
        monster_lifeBar.SetMonsterName(enemy.Name);
        monster_lifeBar.SetLifeBarValue(enemy.MaxLife,monster_recentlife);
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


