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


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        //unpause game
        Time.timeScale = 1f;

        currentSilverCoins = 0;
        UIController.instance.silverCoinText.text = currentSilverCoins.ToString();

        currentCopperCoins = 0;
        UIController.instance.copperCoinText.text = currentCopperCoins.ToString();

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
        CharacterTracker.instance.silverCoins = currentSilverCoins;
        CharacterTracker.instance.copperCoins = currentCopperCoins;
        CharacterTracker.instance.currentHP = PlayerHealthController.instance.currentHitPoints;
        CharacterTracker.instance.maxHP = PlayerHealthController.instance.maxHitPoints;


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

}
