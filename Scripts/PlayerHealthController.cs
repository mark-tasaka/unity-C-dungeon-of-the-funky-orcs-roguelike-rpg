﻿/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;

    public int currentHitPoints;

    public int maxHitPoints;


    private void Awake()
    {
        instance = this;

        UIController.instance.hitPointBar.maxValue = maxHitPoints;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoints;
        UIController.instance.hitPointBar.maxValue = maxHitPoints;
        UIController.instance.hitPointBar.value = currentHitPoints;
        UIController.instance.hitPointText.text = "HP: " + currentHitPoints.ToString() + " / " + maxHitPoints.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DamageToPlayer()
    {
        //to be changed; place holder
        currentHitPoints -= 3;

        UIController.instance.hitPointBar.value = currentHitPoints;
        UIController.instance.hitPointText.text = currentHitPoints.ToString() + " / " + maxHitPoints.ToString();
        
    }
}
