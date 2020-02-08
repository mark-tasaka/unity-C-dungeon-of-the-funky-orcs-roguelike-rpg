/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{

    public GameObject[] potPieces;


    private readonly int minPieces = 3;
    private readonly int maxPieces = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            /*
            if (Input.GetMouseButton(0))
            {*/
                Destroy(gameObject);

                AudioManager.instance.PopFungi();


                int piecesToDrop = Random.Range(minPieces, maxPieces);

                for (int i = 0; i < piecesToDrop; ++i)
                {
                    int randomPiece = Random.Range(0, potPieces.Length);

                    Instantiate(potPieces[randomPiece], transform.position, transform.rotation);

                }
           // }
        }
    }


    //Pot becomes invisible (obj destroyed) when it leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
