using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameControl : MonoBehaviour
{
    Hashtable perLoad = new Hashtable();

    public GameData gameData;
    public PlayData playData;
    public BattleControl battleControl;

    void PerLoadHashTable()
    {
        perLoad.Add("gameData",false);
        perLoad.Add("playData", false);
        perLoad.Add("battleControl", false);

        int a;
        a = PerLoadAssets("1111");
    }

    public int PerLoadAssets(string objectname)
    {
        if (perLoad.Contains(objectname))
        {
            perLoad[objectname] = true;
        }
        else
        {
            Debug.Log("Error Object`s Name");
        }

        if ((bool)perLoad["gameData"] == false)
        {
            gameData.PerLoad();
            return 1;
        }
        if ((bool)perLoad["playData"] == false)
        {
            playData.PerLoad();
            return 1;
        }
        if ((bool)perLoad["battleControl"] == false)
        {
            battleControl.PerLoad();
            return 1;
        }
        battleControl.SetCanBattle();
        return 0;
    }

    private void Start()
    {
        PerLoadHashTable();
    }
}
