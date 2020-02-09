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

    [HideInInspector]
    public bool canMove = true;

    private float AnimSpeed = 0.5f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim.speed = AnimSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        //NEED TO BRING MOVEMENT CONTROLLER OVER


    }
}
