/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Library for UI elements
using UnityEngine.UI;

//Library for SceneManager
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider hitPointBar;
    public Text hitPointText;

    public Text xPoints;

    public Text characterLevel;

    public Text xpGained;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool fadeToBlack, fadeOutBlack;
    
    public Text silverCoinText, copperCoinText;
    
    public string newGameScene, mainMenuScene;

    public GameObject pauseMenu;

    public Text weaponDamageMainScreen, weaponNameInventory;
    

    //Inventory Panel
    public GameObject inventoryPanel;

    //Experience Points Pop up Panel
    public GameObject xpPanel;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeOutBlack = true;
        fadeToBlack = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOutBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                fadeOutBlack = false;
            }
        }

        if (fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }


    }


    public void StartFadeToBlack()
    {
        fadeToBlack = true;
        fadeOutBlack = false;
    }


    public void NewGame()
    {
        //unpause game
        Time.timeScale = 1f;
        SceneManager.LoadScene(newGameScene);

        Destroy(PlayerController.instance.gameObject);
    }

    public void ReturnToMainMenu()
    {
        //unpause game
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);

        Destroy(PlayerController.instance.gameObject);
    }

    public void Resume()
    {
        LevelManager.instance.PauseUnpause();

    }

    public void OpenInventoryPanel()
    {
        inventoryPanel.SetActive(true);
    }


    public void CloseInventoryPanel()
    {
        inventoryPanel.SetActive(false);
    }

}
