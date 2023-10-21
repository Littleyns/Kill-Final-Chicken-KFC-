using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapSize = 5; // Taille de la carte (5x5, par exemple)
    public int roomSize = 29;
    // Les mod�les de salle de diff�rentes tailles (3x3, 4x4, 5x5)
    public GameObject room1Prefab;
    public GameManager gameManager;
    public GameObject[,] map;
    public GameObject wall;
    public GameObject door;

    void Start()
    {
        gameManager = GameObject.FindWithTag("Map").GetComponent<GameManager>();
        room1Prefab = Resources.Load("Room1") as GameObject;
        wall = Resources.Load("Wall_D") as GameObject;
        door = Resources.Load("Interact_Door_A") as GameObject;
    }

    public void GenerateMap()
    {
        map = new GameObject[3 + (gameManager.Difficulty), 3 + (gameManager.Difficulty)];
        for (int x = 0; x < 3+ gameManager.Difficulty; x++)
        {
            for (int z = 0; z < 3+ gameManager.Difficulty; z++)
            {
                // Choisissez une salle en fonction de la difficult�
                GameObject room = GetRandomRoom();

                // Instanciez la salle � la position (x, 0, z)
                GameObject generatedRoom = Instantiate(room, new Vector3(x * roomSize, 0, z * roomSize), Quaternion.identity);
                ManageDoorWays(x, z, generatedRoom);
              


                generatedRoom.transform.SetParent(gameObject.transform);
                map[x,z] = generatedRoom;

            }
        }
    }

    GameObject GetRandomRoom()
    {
        return room1Prefab;
    }

    private void ManageDoorWays(int x, int z, GameObject generatedRoom)
    {
        GameObject doorwayA = generatedRoom.transform.Find("Doorways").Find("Doorway_A").gameObject;
        GameObject doorwayB = generatedRoom.transform.Find("Doorways").Find("Doorway_B").gameObject;
        GameObject doorwayC = generatedRoom.transform.Find("Doorways").Find("Doorway_C").gameObject;
        GameObject doorwayD = generatedRoom.transform.Find("Doorways").Find("Doorway_D").gameObject;
        if (x == 0)
        {
            GameObject generatedWall = Instantiate(wall, doorwayD.transform.position, Quaternion.identity);
            Destroy(doorwayD);
        }
        if (x == 2 + gameManager.Difficulty)
        {
            GameObject generatedWall = Instantiate(wall, doorwayB.transform.position, Quaternion.identity);
            Destroy(doorwayB);
        }
        if (z == 0)
        {
            GameObject generatedWall = Instantiate(wall, doorwayC.transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
            Destroy(doorwayC);
        }
        if (z == 2 + gameManager.Difficulty)
        { 
            GameObject generatedWall = Instantiate(wall, doorwayA.transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
            Destroy(doorwayA);
        }

        if (x != 2 + gameManager.Difficulty)
        {
            Vector3 position = doorwayB.transform.position;

            position.z += 1.23f;
            GameObject generatedDoor = Instantiate(door, position, Quaternion.identity);
           
        }
        if (z != 2 + gameManager.Difficulty)
        {
            Vector3 position = doorwayA.transform.position;
            position.x += 1.23f;
            GameObject generatedDoor = Instantiate(door, position, Quaternion.Euler(new Vector3(0, 90, 0)));
        }
    }
}
