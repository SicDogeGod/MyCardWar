/***********************************************************
 *文件属于基础数据层，用于读取游戏数据                     *
 ***********************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class GameData : MonoBehaviour
{
    public GameControl gameControl;

    public List<Character> characters = new List<Character>();
    public List<Monster> monsters = new List<Monster>();

    public void PerLoad()
    {
        Debug.Log("Start load list data.");

        ReturnCharacterList();
        ReturnMonsterList();

        Debug.Log("Load list data end.");
        gameControl.PerLoadAssets("gameData");
        
    }
    
    void ReturnCharacterList()
    {
        string filepath = Application.dataPath + "/Jsons/CharacterCfg.json.txt";
        string jsonReader = File.ReadAllText(filepath);

        JsonData data = JsonMapper.ToObject(jsonReader);

        for (int i = 0; i < data.Count; i++)
        {
            Character character = new Character
            {
                index = (int)data[i]["index"],
                name = (string)data[i]["name"],
                attack = (string)data[i]["attack"],
                defend = (string)data[i]["defend"],
                life = (string)data[i]["life"],
                speed = (string)data[i]["speed"],
                critical = (int)data[i]["critical"],
                parry = (int)data[i]["parry"],
                inflexible = (int)data[i]["inflexible"],
                keen = (int)data[i]["keen"],
                power = (int)data[i]["power"],
                skillscript = (string)data[i]["skillscript"]
            };
            characters.Add(character);
        }
    }
    void ReturnMonsterList()
    {
        string filepath = Application.dataPath + "/Jsons/MonsterCfg.json.txt";
        string jsonReader = File.ReadAllText(filepath);

        JsonData data = JsonMapper.ToObject(jsonReader);

        for (int i = 0; i < data.Count; i++)
        {
            Monster monster = new Monster
            {
                index = (int)data[i]["index"],
                name = (string)data[i]["name"],
                level = (int)data[i]["level"],
                attack = (string)data[i]["attack"],
                defend = (string)data[i]["defend"],
                life = (string)data[i]["life"],
                speed = (string)data[i]["speed"],
                dropgroup = (int)data[i]["dropgroup"],
                skillscript = (string)data[i]["skillscript"]
            };
            monsters.Add(monster);
        }

    }

    public Character GetCharacterById(int index)
    {
        return characters[index - 1];
    }
}

[SerializeField]
public class Character
{
    public int index;
    public string name;
    public string attack;
    public string defend;
    public string life;
    public string speed;
    public int critical;
    public int parry;
    public int inflexible;
    public int keen;
    public int power;
    public string skillscript;
}

[SerializeField]
public class Monster
{
    public int index;
    public int level;
    public string name;
    public string attack;
    public string defend;
    public string speed;
    public string life;
    public int dropgroup;
    public string skillscript;
}