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
    
    public int xp;

    public string longDescription;

    public int toHitBonus;

    public int minDamage;

    public int maxDamage;

    public int minCritDamage;

    public int maxCritDamage;

    

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
