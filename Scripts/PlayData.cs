using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData : MonoBehaviour
{
    public GameControl gameControl;
    /***********************************************************************************
     * 列表注册
     ***********************************************************************************/
    List<CharacterData> characterdata = new List<CharacterData>();
    // Update is called once per frame
    void Update()
    {

    }

    private List<CharacterData> GetCharacterDatas()
    {
        string jsonReader = File.ReadAllText(Application.dataPath + "/Jsons/Character.json.txt");
        Debug.Log(jsonReader);
        CharacterDatas characterDatas = JsonUtility.FromJson<CharacterDatas>(jsonReader);
        return characterDatas.characterData;
    }

    public void PlayDataStart()
    {
        characterdata = GetCharacterDatas();
        Debug.Log("--游戏数据json加载完毕");
        gameControl.ChangeScriptCheck("playData",true);
    }
    public CharacterData GetCharacter(int id)
    {
        return characterdata[id-1];
    }
}

/*********************************************************************************
 * 
 * 通用的数据类的定义
 * 
 *********************************************************************************/

[Serializable]
public class CharacterData
{
    public int index;
    public string name;
    public float attack;
    public float defend;
    public float life;
    public float speed;
    public float critical;
    public float parry;
    public int level;
    public int inflexible;
    public int keen;
    public int power;
    public string skillscript;
}
[Serializable]
public class CharacterDatas
{
    public List<CharacterData> characterData;
}