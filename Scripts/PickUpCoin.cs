/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    public int coinValue = 1;

    public float waitToBeCollected = 0.5f;

    public bool isSilverCoin;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && waitToBeCollected <= 0f)
        {
            if(isSilverCoin)
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySFX(2);

                LevelManager.instance.GetSilverCoin(coinValue);

            }
            else
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySFX(3);

                LevelManager.instance.GetCopperCoin(coinValue);

            }

        }
            
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && waitToBeCollected <= 0f)
        {
            //health pickUp sound
            AudioManager.instance.PlaySFX(1);

           // LevelManager.instance.GetCoints(coinValue);

            Destroy(gameObject);
        }
    }
*/
}
