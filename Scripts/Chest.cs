﻿/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    //public GunPickUp[] potentialGuns;

    public PickUpCoin[] coinSelection;

    public SpriteRenderer theSR;

    public Sprite chestOpen;

    public GameObject notificaiton;

    private bool canOpen, isOpen;

    public Transform spawnPoint;

    public float scaleSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && !isOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               int selectCoin = Random.Range(0, coinSelection.Length);

                Instantiate(coinSelection[selectCoin], spawnPoint.position, spawnPoint.rotation);
                

                theSR.sprite = chestOpen;

                isOpen = true;

                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

            }
        }

        if (isOpen)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, Time.deltaTime * scaleSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            notificaiton.SetActive(true);

            canOpen = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            notificaiton.SetActive(false);

            canOpen = true;
        }

    }


}
