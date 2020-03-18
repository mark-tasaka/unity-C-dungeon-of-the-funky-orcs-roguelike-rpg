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

   // public GameObject notificaiton;

    private bool canOpen;

    public Transform spawnPoint;

    public float setTimer = 2f;

    public bool hasItem = true;

    // public float scaleSpeed = 2f;


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

                if (hasItem)
                {
                    int selectItem = Random.Range(0, potionSelector.Length);

                    Instantiate(potionSelector[selectItem], spawnPoint.position, spawnPoint.rotation);

                    hasItem = false;
                }


                //theSR.sprite = chestOpen;


                setTimer -= Time.deltaTime;
                
            }
        }


        if (setTimer <= 0f)
        {
            Destroy(gameObject);
        }

        /*
        if (canOpen)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, Time.deltaTime * scaleSpeed);
        }*/
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            canOpen = true;
        }

    }

    //Chest becomes invisible (obj destroyed) when it leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
