/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePointManager : MonoBehaviour
{

    public static ExperiencePointManager instance;

  //  public int currentXp;


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

    public void GetXP(int xp)
    {
        /*
        PlayerStatisticsController.instance.experiencePoints += xp;

        UIController.instance.xPoints.text = PlayerStatisticsController.instance.experiencePoints.ToString();
        */

        int currentXp = PlayerStatisticsController.instance.experiencePoints += xp;

        UIController.instance.xPoints.text = currentXp.ToString();
    }


}
