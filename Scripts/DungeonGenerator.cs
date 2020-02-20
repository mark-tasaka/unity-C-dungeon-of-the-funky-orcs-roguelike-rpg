/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{

    public GameObject layoutRoom;

    //colours to indicate the start and end rooms
    public Color startColour, endColour;

    //number of rooms until the end
    public int distanceToEnd;

    public Transform generatorPoint;

    public enum Direction { up, right, down, left };

    public Direction selectedDirection;

    public float xOffset = 18f;
    public float yOffSet = 10f;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(layoutRoom, generatorPoint.position, generatorPoint.rotation).GetComponent<SpriteRenderer>().color = startColour;
        selectedDirection = (Direction)Random.Range(0, 4);

        MoveGenerationPoint();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void MoveGenerationPoint()
    {
        switch (selectedDirection)
        {
            case Direction.up:
                generatorPoint.position += new Vector3(0f, yOffSet, 0f);
                break;

            case Direction.down:
                generatorPoint.position += new Vector3(0f, -yOffSet, 0f);
                break;

            case Direction.right:
                generatorPoint.position += new Vector3(xOffset, 0f, 0f);
                break;

            case Direction.left:
                generatorPoint.position += new Vector3(-xOffset, 0f, 0f);
                break;

        }

    }
}
