/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;

    [HideInInspector]
    public int currentHitPoints;

    [HideInInspector]
    public int maxHP;

    public bool isStartGame;


    private void Awake()
    {
        instance = this;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        if(isStartGame)
        {
            maxHP = PlayerStatisticsController.instance.maxHitPoints;
            currentHitPoints = maxHP;
        }
        else
        {
            maxHP = CharacterTracker.instance.maxHP;
            currentHitPoints = CharacterTracker.instance.currentHP;

        }
        
        UIController.instance.hitPointBar.maxValue = maxHP;
        UIController.instance.hitPointBar.value = currentHitPoints;
        UIController.instance.hitPointText.text = currentHitPoints.ToString() + " / " + maxHP.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageToPlayer()
    {
        //to be changed; place holder
        currentHitPoints -= 3;

        UIController.instance.hitPointBar.value = currentHitPoints;
        UIController.instance.hitPointText.text = currentHitPoints.ToString() + " / " + maxHP.ToString();
        
    }


    public void FungusEffect(bool fungi)
    {

        if(fungi == true)
        {
            currentHitPoints += 2;

            if (currentHitPoints > maxHP)
            {
                currentHitPoints = maxHP;
            }
                
        }

        if(fungi == false)
        {
            currentHitPoints -= 1;
        }

        UIController.instance.hitPointBar.value = currentHitPoints;
        UIController.instance.hitPointText.text = currentHitPoints.ToString() + " / " + maxHP.ToString();
    }

    //Effects of the fungus spores the players walks into
    /*  
       public void FungusEffect()
      {
          int dieRoll = Random.Range(1, 6);

          if(dieRoll == 1)
          {
              currentHitPoints -= 1;
          }
          else if(dieRoll >=2 && dieRoll <=4)
          {
              currentHitPoints -= 3;
          }
          else if (dieRoll >= 5 && dieRoll <= 6)
          {
              currentHitPoints += 2;

              if(currentHitPoints > maxHitPoints)
              {
                  currentHitPoints = maxHitPoints;
              }
          }

          UIController.instance.hitPointBar.value = currentHitPoints;
          UIController.instance.hitPointText.text = currentHitPoints.ToString() + " / " + maxHitPoints.ToString();
      }
      */



}
