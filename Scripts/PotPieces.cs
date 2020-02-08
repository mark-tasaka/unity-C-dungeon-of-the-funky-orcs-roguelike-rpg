﻿/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotPieces : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float deceleration = 5f;
    public float lifetime = 5f;
    public SpriteRenderer theSR;
    public float fadeSpeed = 2.5f;

    private Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        moveDirection.x = Random.Range(-moveSpeed, moveSpeed);
        moveDirection.y = Random.Range(-moveSpeed, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;

        moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, deceleration * Time.deltaTime);

        lifetime -= Time.deltaTime;

        if (lifetime < 0f)
        {
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, Mathf.MoveTowards(theSR.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (theSR.color.a == 0f)
            {
                Destroy(gameObject);
            }

        }
    }
}
