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
    //public int distanceToEnd;

    //Range of Rooms generated
    public int minRooms = 10, maxRooms = 20;
    private int numberOfRoomsCreated;

    public Transform generatorPoint;

    public enum Direction { up, right, down, left };

    public Direction selectedDirection;

    public float xOffset = 18f;
    public float yOffSet = 10f;

    public LayerMask whatIsRoom;

    private GameObject endRoom;

    private List<GameObject> layoutRoomObject = new List<GameObject>();
    

    private List<GameObject> generatedOutlines = new List<GameObject>();

    //References to roomCentre objects
    public RoomCentre centreStart, centreEnd;

    public RoomCentre[] potentialCentres;


    [Header("Room Arrays")]
    public GameObject[] roomN;
    public GameObject[] roomS;
    public GameObject[] roomE;
    public GameObject[] roomW;

    public GameObject[] roomNS;
    public GameObject[] roomNE;
    public GameObject[] roomNW;
    public GameObject[] roomSE;
    public GameObject[] roomSW;
    public GameObject[] roomEW;

    public GameObject[] roomNSE;
    public GameObject[] roomNSW;
    public GameObject[] roomNEW;
    public GameObject[] roomSEW;

    public GameObject[] roomNSEW;

    // Start is called before the first frame update
    void Start()
    {
        numberOfRoomsCreated = Random.Range(minRooms, maxRooms);

        Instantiate(layoutRoom, generatorPoint.position, generatorPoint.rotation).GetComponent<SpriteRenderer>().color = startColour;
        selectedDirection = (Direction)Random.Range(0, 4);

        MoveGenerationPoint();

        for (int i = 0; i < numberOfRoomsCreated; i++)
        {
            GameObject newRoom = Instantiate(layoutRoom, generatorPoint.position, generatorPoint.rotation);

            //Adding new rooms to the list
            layoutRoomObject.Add(newRoom);

            if (i + 1 == numberOfRoomsCreated)
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

        foreach (GameObject outline in generatedOutlines)
        {
            bool generateCentre = true;

            //checking start position
            if (outline.transform.position == Vector3.zero)
            {
                Instantiate(centreStart, outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();

                generateCentre = false;

            }

            if (outline.transform.position == endRoom.transform.position)
            {
                Instantiate(centreEnd, outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();

                generateCentre = false;

            }

            if (generateCentre)
            {
                int centreSelect = Random.Range(0, potentialCentres.Length);

                 Instantiate(potentialCentres[centreSelect], outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();


               // Instantiate(potentialCentres[0], outline.transform.position, transform.rotation).theRoom = outline.GetComponent<Room>();
            }



        }

    }

    // Update is called once per frame
    void Update()
    {
        //only in Unity Editor
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
#endif
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

        if (roomEast == true)
        {
            directionCount++;
        }

        if (roomWest == true)
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
                    int roomChoiceN = Random.Range(0, roomN.Length);
                    generatedOutlines.Add(Instantiate(roomN[roomChoiceN], roomPosition, transform.rotation));

                }

                if (roomSouth)
                {
                    int roomChoiceS = Random.Range(0, roomS.Length);
                    generatedOutlines.Add(Instantiate(roomS[roomChoiceS], roomPosition, transform.rotation));

                }

                if (roomEast)
                {
                    int roomChoiceE = Random.Range(0, roomE.Length);
                    generatedOutlines.Add(Instantiate(roomE[roomChoiceE], roomPosition, transform.rotation));
                }

                if (roomWest)
                {
                    int roomChoiceW = Random.Range(0, roomW.Length);
                    generatedOutlines.Add(Instantiate(roomW[roomChoiceW], roomPosition, transform.rotation));
                }


                break;

            case 2:
                
                if (roomNorth && roomSouth)
                {
                    int roomChoiceNS = Random.Range(0, roomNS.Length);
                    generatedOutlines.Add(Instantiate(roomNS[roomChoiceNS], roomPosition, transform.rotation));
                }

                if (roomNorth && roomEast)
                {
                    int roomChoiceNE = Random.Range(0, roomNE.Length);
                    generatedOutlines.Add(Instantiate(roomNE[roomChoiceNE], roomPosition, transform.rotation));
                }

                if (roomNorth && roomWest)
                {
                    int roomChoiceNW = Random.Range(0, roomNW.Length);
                    generatedOutlines.Add(Instantiate(roomNW[roomChoiceNW], roomPosition, transform.rotation));
                }

                if (roomSouth && roomEast)
                {
                    int roomChoiceSE = Random.Range(0, roomSE.Length);
                    generatedOutlines.Add(Instantiate(roomSE[roomChoiceSE], roomPosition, transform.rotation));
                }

                if (roomSouth && roomWest)
                {
                    int roomChoiceSW = Random.Range(0, roomSW.Length);
                    generatedOutlines.Add(Instantiate(roomSW[roomChoiceSW], roomPosition, transform.rotation));
                }

                if (roomEast && roomWest)
                {
                    int roomChoiceEW = Random.Range(0, roomEW.Length);
                    generatedOutlines.Add(Instantiate(roomEW[roomChoiceEW], roomPosition, transform.rotation));
                }

                break;

            case 3:

                if (roomNorth && roomSouth && roomEast)
                {
                    int roomChoiceNSE = Random.Range(0, roomNSE.Length);
                    generatedOutlines.Add(Instantiate(roomNSE[roomChoiceNSE], roomPosition, transform.rotation));
                }

                if (roomNorth && roomSouth && roomWest)
                {
                    int roomChoiceNSW = Random.Range(0, roomNSW.Length);
                    generatedOutlines.Add(Instantiate(roomNSW[roomChoiceNSW], roomPosition, transform.rotation));
                }

                if (roomNorth && roomEast && roomWest)
                {
                    int roomChoiceNEW = Random.Range(0, roomNEW.Length);
                    generatedOutlines.Add(Instantiate(roomNEW[roomChoiceNEW], roomPosition, transform.rotation));
                }

                if (roomSouth && roomEast && roomWest)
                {
                    int roomChoiceSEW = Random.Range(0, roomSEW.Length);
                    generatedOutlines.Add(Instantiate(roomSEW[roomChoiceSEW], roomPosition, transform.rotation));
                }

                break;

            case 4:
                
                if (roomNorth && roomSouth && roomEast && roomWest)
                {
                    int roomChoiceNSEW = Random.Range(0, roomNSEW.Length);
                    generatedOutlines.Add(Instantiate(roomNSEW[roomChoiceNSEW], roomPosition, transform.rotation));
                }

                break;

        }

    }



}



