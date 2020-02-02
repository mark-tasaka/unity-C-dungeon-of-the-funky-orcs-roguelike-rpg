/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float movementSpeed = 3.0f;

    private Vector2 movement = new Vector2();

    private Animator animator;

    private string animationState = "AnimationState";

    private Rigidbody2D rb2D;

  //  private Vector2 moveInput;

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


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();

    }

    private void FixedUpdate()
    {
        MoveCharacter();
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

            if (Input.GetKeyUp(KeyCode.RightArrow))
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
