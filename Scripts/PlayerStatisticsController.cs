﻿/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatisticsController : MonoBehaviour
{
    public static PlayerStatisticsController instance;

    public int characterLevel;

    public int experiencePoints;
    
    [HideInInspector]
    public int maxHitPoints;

    [HideInInspector]
    public int currentHitPoints;

    private int baseHitPoints;

    public bool isStartGame;

    public int weaponRanking;

    public GameObject weapon;

    public string weaponName;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        baseHitPoints = BaseHitPoints();

        maxHitPoints = GetMaxHitPoints(characterLevel, baseHitPoints);

        if (isStartGame)
        {
            maxHitPoints = PlayerStatisticsController.instance.maxHitPoints;
            currentHitPoints = maxHitPoints;
        }
        else
        {
            maxHitPoints = CharacterTracker.instance.maxHP;
            currentHitPoints = CharacterTracker.instance.currentHP;

        }

        UIController.instance.hitPointBar.maxValue = maxHitPoints;
        UIController.instance.hitPointBar.value = currentHitPoints;
        UIController.instance.hitPointText.text = currentHitPoints.ToString() + " / " + maxHitPoints.ToString();

        //Experience Points
        if(isStartGame)
        {
            experiencePoints = 0;
        }
        else
        {
            experiencePoints = CharacterTracker.instance.experiencePoints;
        }
        UIController.instance.xPoints.text = experiencePoints.ToString();

        //CharacterLevel
        if (isStartGame)
        {
            characterLevel = 1;
        }
        else
        {
            characterLevel = CharacterTracker.instance.characterLevel;
        }
        UIController.instance.characterLevel.text = "Lv: " + characterLevel.ToString();

        weapon = InventoryManager.instance.weapons[weaponRanking];
        

        /*
        if(isStartGame)
        {
            weaponRanking = 0;
        }
        else
        {
            weaponRanking = CharacterTracker.instance.characterWeaponRank;
        }
        weapon = GetWeapon(weaponRanking);

        UIController.instance.weaponDamageMainScreen.text = Weapon.instance.WeaponStats;
        */

        //Use Temporary until figure out solution
        /*
        string weaponName = 
        UIController.instance.weaponDamageMainScreen.text =
        */


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int BaseHitPoints()
    {
        int baseHP = Random.Range(5, 10);

        return baseHP;
    }

    public int GetMaxHitPoints(int level, int baseHP)
    {
        int maxHitPoints = 0;

        if (level == 1)
        {
            maxHitPoints = baseHP;
        }

        return maxHitPoints;
    }


   public GameObject GetWeapon(int ranking)
    {
        weapon = InventoryManager.instance.weapons[ranking];

        return weapon;
    }




}
