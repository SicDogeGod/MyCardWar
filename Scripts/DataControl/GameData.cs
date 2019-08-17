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
    public List<Charactor> charactors = new List<Charactor>();
    // Start is called before the first frame update
    void Start()
    {
        ReturnCharacterList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnCharacterList()
    {
        string filepath = Application.dataPath + "/Jsons/Character.json.txt";
        string jsonReader = File.ReadAllText(filepath);

        JsonData data = JsonMapper.ToObject(jsonReader);

        for (int i = 0; i < data.Count; i++)
        {
            Charactor character = new Charactor
            {
                index = (string)data[i]["index"],
                name = (string)data[i]["name"],
                attack = (string)data[i]["attack"],
                defend = (string)data[i]["defend"],
                life = (string)data[i]["life"],
                speed = (string)data[i]["speed"],
                critical = (string)data[i]["critical"],
                parry = (string)data[i]["parry"],
                level = (string)data[i]["level"],
                inflexible = (string)data[i]["inflexible"],
                keen = (string)data[i]["keen"],
                power = (string)data[i]["power"],
                skillscript = (string)data[i]["skillscript"]
            };
            charactors.Add(character);
        }
        Debug.Log(charactors[0].index);
        Debug.Log(charactors[1].index);
    }
}

[SerializeField]
public class Charactor
{
    public string index;
    public string name;
    public string attack;
    public string defend;
    public string life;
    public string speed;
    public string critical;
    public string parry;
    public string level;
    public string inflexible;
    public string keen;
    public string power;
    public string skillscript;
}
