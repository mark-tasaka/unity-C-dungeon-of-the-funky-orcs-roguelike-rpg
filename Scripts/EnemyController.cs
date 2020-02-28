/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D theRB;
    public SpriteRenderer theBody;
    public float moveSpeed;
    public float rangeToAttackPlayer;
    public int hitPointsMinRange;
    public int hitPointsMaxRange;
    public int Defence;
    public int attackBonus;

    private int hitPoints;
    private Vector3 moveDirection;
   // private float AnimSpeed = 0.5f;

    /*
     * Create different behavours for different
     * enemy reactions:
     * 1. Attack
     * 2. Flee
     * 3. Wander
     * 
     * public float reaction range;
     */


    // Start is called before the first frame update
    void Start()
    {
        //anim.speed = AnimSpeed;

        hitPoints = GenerateHitPoints(hitPointsMinRange, hitPointsMaxRange);

        print("Hit points: " + hitPoints);

    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Add different if statement for different behavious of enenmy
         */
         

        if (theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToAttackPlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;

            }
            else
            {
                moveDirection = Vector3.zero;
            }

            moveDirection.Normalize();

            theRB.velocity = moveDirection * moveSpeed;
        }




    }//End Update()

    //Generates random enemy hit points
    private int GenerateHitPoints(int min, int max)
    {
        int hitPoints = Random.Range(min, max);

        return hitPoints;
    }

}


