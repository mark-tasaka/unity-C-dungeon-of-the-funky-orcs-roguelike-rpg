/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public static PickUpCoin instance;

    public int coinValue = 1;

    public int xp = 1;

    public float waitToBeCollected = 0.1f;

    public bool isSilverCoin;

    //Fix this issue
    public float xpPanelLive = 1f;
    private bool startTimer;


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

        if (waitToBeCollected > 0f)
        {
            waitToBeCollected -= Time.deltaTime;
        }

        if(startTimer)
        {
            xpPanelLive -= Time.deltaTime;
        }

        if(xpPanelLive <= 0f)
        {
            UIController.instance.xpPanel.SetActive(false);

            startTimer = false;
            xpPanelLive = 1f;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && waitToBeCollected <= 0f)
        {
            
            if (isSilverCoin)
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySFX(2);

                LevelManager.instance.GetSilverCoin(coinValue);

                LevelManager.instance.GetXP(xp);

                startTimer = true;
                UIController.instance.xpPanel.SetActive(true);
                UIController.instance.xpGained.text = "+" + xp.ToString() + " XP";
                

            }
            else
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySFX(3);

                LevelManager.instance.GetCopperCoin(coinValue);

                LevelManager.instance.GetXP(xp);

                startTimer = true;
                UIController.instance.xpPanel.SetActive(true);
                UIController.instance.xpGained.text = "+" + xp.ToString() + " XP";

            }

        }
            
    }
    
}
