/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool shouldChasePlayer;

    public float rangeToChasePlayer;

    public bool shouldRunAway;

    public float runAwayRange;

    //wandering enemy
    public bool shouldWander;
    public float wanderLength, pauseLength;
    private float wanderCounter, pauseCounter;
    private Vector3 wanderDirection;

    public Animator anim;

    //lower the value, the slower the animation
    public float AnimSpeed = 0.3f;

    private Vector3 moveDirection;
    

    public SpriteRenderer theBody;


    // Start is called before the first frame update
    void Start()
    {
        anim.speed = AnimSpeed;

        if (shouldWander)
        {
            pauseCounter = Random.Range(pauseLength * 0.75f, pauseLength * 1.25f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Vector3.zero;

        if (theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer && shouldChasePlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;

            }
            else
            {

                //Wandering enemy
                if (shouldWander)
                {
                    if (wanderCounter > 0)
                    {
                        wanderCounter -= Time.deltaTime;

                        //move enemy
                        moveDirection = wanderDirection;


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

                            wanderDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                        }
                    }
                }
            }

            //Coward enemy
            if (shouldRunAway && Vector3.Distance(transform.position, PlayerController.instance.transform.position) < runAwayRange)
            {
                //exact opposite move direct as above
                moveDirection = transform.position - PlayerController.instance.transform.position;
            }



            /*
            else
            {
                moveDirection = Vector3.zero;
            }
            */

            moveDirection.Normalize();

            theRB.velocity = moveDirection * moveSpeed;

            
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }



        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }


    }//end Update()



}
