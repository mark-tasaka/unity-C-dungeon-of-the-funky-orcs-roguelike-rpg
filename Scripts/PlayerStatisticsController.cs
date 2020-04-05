/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Library for UI elements
using UnityEngine.UI;

public class PlayerStatisticsController : MonoBehaviour
{
    public static PlayerStatisticsController instance;

    public int characterLevel;

    public int experiencePoints;
    
    [HideInInspector]
    public int maxHitPoints;

    [HideInInspector]
    public int currentHitPoints;

    private int baseHitPoints;

    public bool isStartGame;

    public int weaponRanking = 0;


    [Header("Character's Weapon:")]
    public GameObject[] weaponsArray;
    private GameObject currentWeapon;
    private string weaponName;
    private SpriteRenderer weaponIcon;

    /*
     * WORK ON THIS
    [Header("UI Life")]
    public GameObject[] lifeArray;
    public int lifeElementCounter = 0;
    public GameObject currentLifeIcon;
    public SpriteRenderer lifeIcon;
    */

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

        /*
         * 
         * WORK ON THIS
         * 
        lifeElementCounter = GetLifeIcon(currentHitPoints, maxHitPoints);

        currentLifeIcon = lifeArray[lifeElementCounter];

        lifeIcon = currentLifeIcon.GetComponent<LifeIcon>().iconImage;

        UIController.instance.heartIcon.sprite = lifeIcon.sprite;
        */

        UIController.instance.hitPointText.text = currentHitPoints.ToString() + " / " + maxHitPoints.ToString();

        //Experience Points
        if(isStartGame)
        {
            experiencePoints = 0;
        }
        else
        {
            experiencePoints = CharacterTracker.instance.experiencePoints;
        }
        UIController.instance.xPoints.text = experiencePoints.ToString();

        //CharacterLevel
        if (isStartGame)
        {
            characterLevel = 1;
        }
        else
        {
            characterLevel = CharacterTracker.instance.characterLevel;
        }
        UIController.instance.characterLevel.text = "Lv: " + characterLevel.ToString();

        
        /*
        if(isStartGame)
        {
            weaponRanking = 0;
        }
        else
        {
            weaponRanking = CharacterTracker.instance.characterWeaponRank;
        }
        */

        currentWeapon = weaponsArray[weaponRanking];

        //weaponIcon = currentWeapon.GetComponent<Weapon>().inventoryDisplay;

        weaponName = currentWeapon.GetComponent<Weapon>().weaponName;

        weaponIcon = currentWeapon.GetComponent<Weapon>().uIDisplay;

        //weaponIcon = currentWeapon.GetComponent<Weapon>().inventoryDisplay;

        UIController.instance.weaponIcon.sprite = weaponIcon.sprite;

        /*  To hit + Weapon Damage */

        UIController.instance.weaponDamageMainScreen.text = weaponName.ToString();


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

    //To Determine which Heart symbol is displayed in the UI
    //Each time player takes damage call this function
    public int GetLifeIcon (int currentHP, int maxHP)
    {
        float current = (float)currentHP;
        float max = (float)maxHP;
        int arrayPosition = 0;

        float healthPercent = current / max;
        
        if (healthPercent > 0.5f && healthPercent < 0.75f)
        {
            arrayPosition = 1;
        }

        if (healthPercent > 0.25f && healthPercent < 0.5f)
        {
            arrayPosition = 2;
        }

        if (healthPercent < 0.25f)
        {
            arrayPosition = 3;
        }

        return arrayPosition;
    }
    




}
