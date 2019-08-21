using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControl : MonoBehaviour
{
    bool canStartBattle = false;

    public Character character;
    string character_name;
    float character_maxLife;
    float character_recentLife;

    public Monster monster;
    float monster_recentLife;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBattleStart()
    {
        character_name = character.name;
        character_maxLife = float.Parse(character.life);
        character_recentLife = character_maxLife;


    }

    void OnBattleIn()
    {
        do {

        } while (character_recentLife < 0 || monster_recentLife < 0);
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

