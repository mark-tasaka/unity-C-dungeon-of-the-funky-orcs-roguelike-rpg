﻿/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //CLASS MY BE UNNECESSARY.  FUNCTIONALITY MAY BE BEST FOR PlayerStatisticsController.cs


    //store Player items, weapons, armour

    public static Inventory instance;

    //public GameObject weapon = InventoryManager.instance.weapons[0];
    

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
