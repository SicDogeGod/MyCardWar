using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData : MonoBehaviour
{
    public GameControl gameControl;

    string[] playDatasKey = new string[] 
    {
        //用户信息
        "user_count",
        "user_password",

        //角色信息
        "play_name",
        "play_level",
        "play_money",
        
        //游戏进程
            //玩家角色解锁
        "character_unlock01",

        //游戏进程
            //玩家道具解锁
        "item_unlock01"
    };
    public void PerLoad()
    {
        Debug.Log("Start load play data.");

        OnCreaterCounter();

        Debug.Log("End load play data.");
        gameControl.PerLoadAssets("playData");

        
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
        PlayerPrefs.SetString(playDatasKey[3],"testname");
        PlayerPrefs.SetInt(playDatasKey[4],10);
    }


}

public class Player
{
    public string Name { get; set; }
    public float MaxLife { get; set; }
    public float Attack { get; set; }
    public float Defend { get; set; }

    public float Defend_rate { get; set; }
    public float Critical_rate { get; set; }
    public float Parry_rate { get; set; }

    public float Speed { get; set; }
    public float Critical { get; set; }
    public float Parry { get; set; }

    public int Inflexable { get; set; }
    public int Keen { get; set; }
    public int Power { get; set; }

    public int Level { get; set; }


    public Player(string pname,int plevel)
    {
        Level = plevel;
        Name = pname;
    }

    public void SetAttriblity(Character character)
    {
        MaxLife = float.Parse(character.life) + 2 * character.inflexible + 1 * character.power;
        Attack = float.Parse(character.attack) + 1.5f * Power;
        Defend = float.Parse(character.defend) + 1.5f * Inflexable;

        Defend_rate = GetDefendRate(Defend,Level);

        Speed = float.Parse(character.speed);

        Critical = character.critical;

        Critical_rate = GetCriticalRate(Critical);

        Parry = character.parry;

        Parry_rate = GetParryRate(Parry);
    }

    float GetDefendRate(float pdefend,int plevel)
    {
        float rate = Mathf.Log(pdefend,1.15f) + plevel;
        return rate;
    }
    float GetCriticalRate(float pcritical)
    {
        return pcritical / 100;
    }
    float GetParryRate(float pparry)
    {
        return pparry / 100;
    }
}

public class Enemy
{
    public string Name { get; set; }
    public float Attack { get; set; }
    public float MaxLife { get; set; }
    public float Defend { get; set; }
    public int Level { get; set; }
    public float Speed { get; set; }
    public float DropGroup { get; set; }

    public float Defend_rate { get; set; }

    public Enemy(Monster monster)
    {
        Name = monster.name;
        Level = monster.level;
        MaxLife = float.Parse(monster.life);
        Attack = float.Parse(monster.attack);
        Defend = float.Parse(monster.defend);
        Defend_rate = GetDefendRate(Defend,Level);
        Speed = float.Parse(monster.speed);
        DropGroup = monster.dropgroup;
    }

    float GetDefendRate(float edefend,float elevel)
    {
        return (Mathf.Log(Defend,1.15f)+Level);
    }
}