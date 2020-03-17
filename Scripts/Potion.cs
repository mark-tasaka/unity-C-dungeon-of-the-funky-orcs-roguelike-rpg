/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public string potionName;

    public float waitToBeCollected = 0.1f;


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

            AudioManager.instance.PlaySFX(4);

            Destroy(gameObject);

            //Create Inventory.cs class to store potion
            //Call instance of Inventory.cs for potion

        }
    }
}
