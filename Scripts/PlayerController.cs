/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //static - set for all version of PlayerController script
    public static PlayerController instance;

    public Animator anim;

    public float movementSpeed = 3.0f;

    [HideInInspector]
    public bool canMove = true;


    //private accessors

    private readonly float AnimSpeed = 0.5f;

    private Animator animator;

    private Rigidbody2D rb2D;

    private Vector2 movement = new Vector2();

    private string animationState = "AnimationState";

   // private bool stopRight = false;

    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleEast = 5,
        idleSouth = 6,
        idleWest = 7,
        idleNoth = 8
    }


    private void Awake()
    {
        instance = this;

        //Do not destroy Player (target) object
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim.speed = AnimSpeed;
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
     {
        //NEED TO FIX PAUSE, WALKING IN ONE DIRECTION ISSUE
         if(canMove && !LevelManager.instance.isPaused)
         {
             UpdateState();
         }
         else
         {
             rb2D.velocity = Vector2.zero;
             anim.SetBool("isMoving", false);
         }

         //NEED TO BRING MOVEMENT CONTROLLER OVER
     }

    private void FixedUpdate()
    {
        if (canMove)
        {
            MoveCharacter();
        }
        else
        {
            rb2D.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb2D.velocity = movement * movementSpeed;
    }



    private void UpdateState()
    {


        /*
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        */

        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);

            //Need to work on
            if (movement.x == 0)
            {
                animator.SetInteger(animationState, (int)CharStates.idleEast);
            }

        }


        if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }

        if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }

        if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }

        /*

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetInteger(animationState, (int)CharStates.idleEast);
        }
        */



        /*
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        */

    }



}
