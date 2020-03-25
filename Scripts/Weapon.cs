/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;

    public SpriteRenderer inventoryDisplay;
    
    public string weaponName;

    public string weaponStats;
    
        /*
    public string WeaponStats
    {
        get { return WeaponStats; }
        set { WeaponStats = WeaponStats; }
    }*/

   // public string WeaponStats { get; set; }

    //public string shortDescription;

    public int xp;

    public string longDescription;

    public int toHitBonus;

    public int minDamage;

    public int maxDamage;

    public int minCritDamage;

    public int maxCritDamage;


    //Ctor
    /*
    public Weapon(string weaponStat)
    {
        WeaponStats = weaponStat;
    }
    */

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
