/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For Scene Manager
using UnityEngine.SceneManagement;

public class SurvivedDungeon : MonoBehaviour
{

    public float waitForAnyKey = 2.0f;

    public GameObject anyKeyText;

    public string loadScene;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForAnyKey > 0)
        {
            waitForAnyKey -= Time.deltaTime;

            if (waitForAnyKey <= 0)
            {
                anyKeyText.SetActive(true);
            }
        }
        else
        {
            //covers all key enters
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(loadScene);
            }
        }

    }
}
