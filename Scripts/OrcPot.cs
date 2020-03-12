/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcPot : MonoBehaviour
{

    public SpriteRenderer theSR;

    public GameObject[] potPieces;

    public PickUpCoin[] coinSelection;

    private readonly int minPieces = 3;
    private readonly int maxPieces = 6;

    private bool canSmash;

    public Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canSmash)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySFX(1);


                int piecesToDrop = Random.Range(minPieces, maxPieces);


                for (int i = 0; i < piecesToDrop; ++i)
                {
                    int randomPiece = Random.Range(0, potPieces.Length);

                    Instantiate(potPieces[randomPiece], transform.position, transform.rotation);
                }

                int selectCoin = Random.Range(0, coinSelection.Length);

                Instantiate(coinSelection[selectCoin], spawnPoint.position, spawnPoint.rotation);

            }
        }

    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            canSmash = true;
        }

    }


    //Pot becomes invisible (obj destroyed) when it leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
