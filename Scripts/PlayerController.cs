/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;

    private float AnimSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        anim.speed = AnimSpeed;

    }

    // Update is called once per frame
    void Update()
    {


    }
}
