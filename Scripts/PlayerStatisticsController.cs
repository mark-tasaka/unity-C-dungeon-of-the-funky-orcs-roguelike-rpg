/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatisticsController : MonoBehaviour
{
    public static PlayerStatisticsController instance;

    public int characterLevel = 1;
    
    [HideInInspector]
    public int maxHitPoints;
    
    private int baseHitPoints;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        baseHitPoints = BaseHitPoints();

        maxHitPoints = GetMaxHitPoints(characterLevel, baseHitPoints);


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
        int maxHP = 0;

        if (level == 1)
        {
            maxHP = baseHP;
        }

        return maxHP;
    }

}
