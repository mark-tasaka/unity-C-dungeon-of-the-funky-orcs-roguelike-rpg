/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fungus : MonoBehaviour
{

    public static Fungus instance;

    public GameObject[] fungiPiecesHeal;
    public GameObject[] fungiPiecesHarm;


    private readonly int minPieces = 3;
    private readonly int maxPieces = 6;

    private bool isGoodFungus = false;

    private void Awake()
    {
        instance = this;
    }

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

            AudioManager.instance.PopFungi();

            int die = Random.Range(1, 4);

            if (die < 3)
            {
                isGoodFungus = true;

                //Fungus Effect
                FungusEffect(isGoodFungus);

                int piecesToDrop = Random.Range(minPieces, maxPieces);

                for (int i = 0; i < piecesToDrop; ++i)
                {
                    int randomPiece = Random.Range(0, fungiPiecesHeal.Length);

                    Instantiate(fungiPiecesHeal[randomPiece], transform.position, transform.rotation);

                }
            }
            else
            {
                //Fungus Effect
                FungusEffect(isGoodFungus);

                int piecesToDrop = Random.Range(minPieces, maxPieces);

                for (int i = 0; i < piecesToDrop; ++i)
                {
                    int randomPiece = Random.Range(0, fungiPiecesHarm.Length);

                    Instantiate(fungiPiecesHarm[randomPiece], transform.position, transform.rotation);

                }

            }

        }
    }

    //Fungus becomes invisible (obj destroyed) when it leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }





    public void FungusEffect(bool fungi)
    {

        if (fungi == true)
        {
            PlayerStatisticsController.instance.currentHitPoints += 2;

            if (PlayerStatisticsController.instance.currentHitPoints > PlayerStatisticsController.instance.maxHitPoints)
            {
                PlayerStatisticsController.instance.currentHitPoints = PlayerStatisticsController.instance.maxHitPoints;
            }

        }

        if (fungi == false)
        {
            PlayerStatisticsController.instance.currentHitPoints -= 1;
        }

        UIController.instance.hitPointBar.value = PlayerStatisticsController.instance.currentHitPoints;
        UIController.instance.hitPointText.text = PlayerStatisticsController.instance.currentHitPoints.ToString() + " / " + PlayerStatisticsController.instance.maxHitPoints.ToString();
    }


}
