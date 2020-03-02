/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySporeBallBehaviour : MonoBehaviour
{
    
    public Rigidbody2D theRB;
    public SpriteRenderer theSpore;
    public float moveSpeed = 4f;

    public float wanderLength = 4.0f, pauseLength = 1.5f;

    private float wanderCounter, pauseCounter;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {

        pauseCounter = Random.Range(pauseLength * 0.75f, pauseLength * 1.25f);

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Vector3.zero;
        
        if (theSpore.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {


            if (wanderCounter > 0)

            {

                wanderCounter -= Time.deltaTime;
            


                if (wanderCounter <= 0)
                {
                    pauseCounter = Random.Range(pauseLength * 0.75f, pauseLength * 1.25f);
                }

            }

            if (pauseCounter > 0)
            {
                pauseCounter -= Time.deltaTime;

                if (pauseCounter <= 0)
                {
                    wanderCounter = Random.Range(wanderLength * 0.75f, wanderLength * 1.25f);

                    moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                }
            }

        }
    }

}
