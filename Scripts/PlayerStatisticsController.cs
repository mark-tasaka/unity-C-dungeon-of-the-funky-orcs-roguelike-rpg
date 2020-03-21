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

    [HideInInspector]
    public int currentHitPoints;

    private int baseHitPoints;

    public bool isStartGame;

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

    /*
    public void FungusEffect(bool fungi)
    {

        if (fungi == true)
        {
            currentHitPoints += 2;

            if (currentHitPoints > maxHitPoints)
            {
                currentHitPoints = maxHitPoints;
            }

        }

        if (fungi == false)
        {
            currentHitPoints -= 1;
        }

        UIController.instance.hitPointBar.value = currentHitPoints;
        UIController.instance.hitPointText.text = currentHitPoints.ToString() + " / " + maxHitPoints.ToString();
    }
    */


}
