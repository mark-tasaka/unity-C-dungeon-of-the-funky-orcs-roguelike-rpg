/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fungus : MonoBehaviour
{
    public GameObject[] fungiPieces;


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
            Destroy(gameObject);

            //Fungus Effect
            PlayerHealthController.instance.FungusEffect();
            
            int piecesToDrop = Random.Range(minPieces, maxPieces);

            for (int i = 0; i < piecesToDrop; ++i)
            {
                int randomPiece = Random.Range(0, fungiPieces.Length);

                Instantiate(fungiPieces[randomPiece], transform.position, transform.rotation);

            }
        }
    }
}
