/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public Potion[] potionSelector;

    public SpriteRenderer theSR;

    public Sprite chestOpen;
    
    private bool canOpen, startTimer;

    public Transform spawnPoint;

    public float timer = 2f;

    public bool hasItem = true;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                theSR.sprite = chestOpen;

                AudioManager.instance.PlaySFX(5);

                if (hasItem)
                {
                    int selectItem = Random.Range(0, potionSelector.Length);

                    Instantiate(potionSelector[selectItem], spawnPoint.position, spawnPoint.rotation);

                    //set to false as it will avoid respawning items each time mouse button pressed
                    hasItem = false;
                }

                startTimer = true;
                
                
            }
        }
        
        if(startTimer)
        {
            timer -= Time.deltaTime;
        }


        if (timer <= 0.0f)
        {
            Destroy(gameObject);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }


    }

    //Chest becomes invisible (obj destroyed) when it leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
