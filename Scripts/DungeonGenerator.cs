/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public LayerMask whatIsRoom;

    private GameObject endRoom;

    private List<GameObject> layoutRoomObject = new List<GameObject>();
    
    public RoomPrefabs rooms;

    private List<GameObject> generatedOutlines = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(layoutRoom, generatorPoint.position, generatorPoint.rotation).GetComponent<SpriteRenderer>().color = startColour;
        selectedDirection = (Direction)Random.Range(0, 4);

        MoveGenerationPoint();

        for (int i = 0; i < distanceToEnd; i++)
        {
            GameObject newRoom = Instantiate(layoutRoom, generatorPoint.position, generatorPoint.rotation);

            //Adding new rooms to the list
            layoutRoomObject.Add(newRoom);

            if (i + 1 == distanceToEnd)
            {
                newRoom.GetComponent<SpriteRenderer>().color = endColour;

                //do not add end room
                layoutRoomObject.RemoveAt(layoutRoomObject.Count - 1);

                endRoom = newRoom;
            }

            selectedDirection = (Direction)Random.Range(0, 4);

            MoveGenerationPoint();

            //check if not overlapping
            while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, whatIsRoom))
            {
                //move the generationPoint again
                MoveGenerationPoint();
            }

        }

        //Create Room Outline
        CreateRoomOutline(Vector3.zero);

        foreach (GameObject room in layoutRoomObject)
        {
            CreateRoomOutline(room.transform.position);
        }

        CreateRoomOutline(endRoom.transform.position);


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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


    public void CreateRoomOutline(Vector3 roomPosition)
    {
        bool roomNorth = Physics2D.OverlapCircle(roomPosition + new Vector3(0f, yOffSet, 0f), 0.2f, whatIsRoom);
        bool roomSouth = Physics2D.OverlapCircle(roomPosition + new Vector3(0f, -yOffSet, 0f), 0.2f, whatIsRoom);
        bool roomWest = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0f, 0f), 0.2f, whatIsRoom);
        bool roomEast = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0f, 0f), 0.2f, whatIsRoom);

        int directionCount = 0;

        if (roomNorth == true)
        {
            directionCount++;
        }

        if (roomSouth == true)
        {
            directionCount++;
        }

        if (roomWest == true)
        {
            directionCount++;
        }

        if (roomEast == true)
        {
            directionCount++;
        }

        switch (directionCount)
        {
            //error case
            case 0:
                Debug.LogError("Found no room exists");
                break;

            case 1:
                if (roomNorth)
                {
                    generatedOutlines.Add(Instantiate(rooms.north, roomPosition, transform.rotation));
                }

                if (roomSouth)
                {
                    generatedOutlines.Add(Instantiate(rooms.south, roomPosition, transform.rotation));
                }

                if (roomWest)
                {
                    generatedOutlines.Add(Instantiate(rooms.west, roomPosition, transform.rotation));
                }

                if (roomEast)
                {
                    generatedOutlines.Add(Instantiate(rooms.east, roomPosition, transform.rotation));
                }


                break;

            case 2:
                
                if (roomNorth && roomSouth)
                {
                    generatedOutlines.Add(Instantiate(rooms.northSouth, roomPosition, transform.rotation));
                }

                if (roomNorth && roomEast)
                {
                    generatedOutlines.Add(Instantiate(rooms.northEast, roomPosition, transform.rotation));
                }

                if (roomNorth && roomWest)
                {
                    generatedOutlines.Add(Instantiate(rooms.northWest, roomPosition, transform.rotation));
                }

                if (roomSouth && roomEast)
                {
                    generatedOutlines.Add(Instantiate(rooms.southEast, roomPosition, transform.rotation));
                }

                if (roomSouth && roomWest)
                {
                    generatedOutlines.Add(Instantiate(rooms.southWest, roomPosition, transform.rotation));
                }

                if (roomEast && roomWest)
                {
                    generatedOutlines.Add(Instantiate(rooms.eastWest, roomPosition, transform.rotation));
                }

                break;

            case 3:

                if (roomNorth && roomSouth && roomEast)
                {
                    generatedOutlines.Add(Instantiate(rooms.northSouthEast, roomPosition, transform.rotation));
                }

                if (roomNorth && roomSouth && roomWest)
                {
                    generatedOutlines.Add(Instantiate(rooms.northSouthWest, roomPosition, transform.rotation));
                }

                if (roomNorth && roomEast && roomWest)
                {
                    generatedOutlines.Add(Instantiate(rooms.northEastWest, roomPosition, transform.rotation));
                }

                if (roomSouth && roomEast && roomWest)
                {
                    generatedOutlines.Add(Instantiate(rooms.southEastWest, roomPosition, transform.rotation));
                }

                break;

            case 4:
                
                if (roomNorth && roomSouth && roomEast && roomWest)
                {
                    generatedOutlines.Add(Instantiate(rooms.northSouthEastWest, roomPosition, transform.rotation));
                }

                break;

        }

    }



}


//Unity process it as a data object being stored
[System.Serializable]
public class RoomPrefabs
{

    public GameObject north, south, east, west,
        northSouth, northEast, northWest, southEast, southWest, eastWest,  
       northSouthEast, northSouthWest, northEastWest, southEastWest,
        northSouthEastWest;
}

