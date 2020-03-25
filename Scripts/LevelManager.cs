/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public float waitToLoad = 4.0f;

    public string nextLevel;

    //is the Game Paused?
    public bool isPaused;

    public int currentSilverCoins;

    public int currentCopperCoins;

    public int currentXP;

    public Transform startPoint;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance.transform.position = startPoint.position;

        PlayerController.instance.canMove = true;

        //unpause game
        Time.timeScale = 1f;

        currentSilverCoins = 0;
        UIController.instance.silverCoinText.text = currentSilverCoins.ToString();

        currentCopperCoins = 0;
        UIController.instance.copperCoinText.text = currentCopperCoins.ToString();

        currentXP = PlayerStatisticsController.instance.experiencePoints;
        UIController.instance.xPoints.text = currentXP.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }

    }

    //coroutine: happens at a different time rate than everything else
    public IEnumerator LevelEnd()
    {

        AudioManager.instance.NextLevel();

        PlayerController.instance.canMove = false;
        UIController.instance.StartFadeToBlack();

        //wait in the middle of a coroutine
        yield return new WaitForSeconds(waitToLoad);

        //To be carried over to the next dungeon level
        //Character Stats
        CharacterTracker.instance.characterLevel = PlayerStatisticsController.instance.characterLevel;
        CharacterTracker.instance.experiencePoints = PlayerStatisticsController.instance.experiencePoints;
        CharacterTracker.instance.currentHP = PlayerStatisticsController.instance.currentHitPoints;
        CharacterTracker.instance.maxHP = PlayerStatisticsController.instance.maxHitPoints;
        //Character Items
        CharacterTracker.instance.silverCoins = currentSilverCoins;
        CharacterTracker.instance.copperCoins = currentCopperCoins;

        CharacterTracker.instance.characterLevel = PlayerStatisticsController.instance.characterLevel;
        CharacterTracker.instance.characterWeaponRank = PlayerStatisticsController.instance.weaponRanking;
        
        SceneManager.LoadScene(nextLevel);
    }


    public void PauseUnpause()
    {
        if (!isPaused)
        {
            UIController.instance.pauseMenu.SetActive(true);
            isPaused = true;
            //stops progession of time in Game
            Time.timeScale = 0f;
        }
        else
        {
            UIController.instance.pauseMenu.SetActive(false);
            isPaused = false;
            //unpause game
            Time.timeScale = 1f;
        }
    }


    public void GetSilverCoin(int amount)
    {
        currentSilverCoins += amount;

        UIController.instance.silverCoinText.text = currentSilverCoins.ToString();
    }

    public void GetCopperCoin(int amount)
    {
        currentCopperCoins += amount;

        UIController.instance.copperCoinText.text = currentCopperCoins.ToString();
    }


    public void GetXP(int xp)
    {

        currentXP += xp;

        UIController.instance.xPoints.text = currentXP.ToString();
    }

}
