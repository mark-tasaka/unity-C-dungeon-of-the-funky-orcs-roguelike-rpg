/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public static Shield instance;

    public string shieldName;

    public SpriteRenderer uIDisplay;

    public SpriteRenderer inventoryDisplay;

    public string shieldDescription;

    public int defenseBonus;

    public int shieldRating;

    public int xp;

    public bool negatesCrit;

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
