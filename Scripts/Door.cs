/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] doors;

    private GameObject theDoor;

    private bool isDoorOpen = false;


    // Start is called before the first frame update
    void Start()
    {

        theDoor = doors[0];

        if(isDoorOpen == false)
        {
            theDoor = doors[0];
        }
        else
        {
            theDoor = doors[1];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(isDoorOpen == false)
            {
                theDoor = doors[1];
            }

            if (isDoorOpen == true)
            {
                theDoor = doors[0];
            }

        }
    }
}
