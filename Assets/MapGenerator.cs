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

    void Start()
    {
        gameManager = GameObject.FindWithTag("Map").GetComponent<GameManager>();
        room1Prefab = Resources.Load("Room1") as GameObject;
        wall = Resources.Load("Wall_D") as GameObject;
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

                if(x==0)
                {
                    GameObject door = generatedRoom.transform.Find("Doorways").Find("Doorway_D").gameObject;
                    GameObject generatedWall = Instantiate(wall, door.transform.position, Quaternion.identity);
                    Destroy(door);
                }
                if(x == 2 + gameManager.Difficulty)
                {
                    GameObject door = generatedRoom.transform.Find("Doorways").Find("Doorway_B").gameObject;
                    GameObject generatedWall = Instantiate(wall, door.transform.position, Quaternion.identity);
                    Destroy(door);
                }
                if (z == 0)
                {
                    GameObject door = generatedRoom.transform.Find("Doorways").Find("Doorway_D").gameObject;
                    GameObject generatedWall = Instantiate(wall, door.transform.position, Quaternion.identity);
                    Destroy(door);
                }
                if (z == 2 + gameManager.Difficulty)
                {
                    GameObject door = generatedRoom.transform.Find("Doorways").Find("Doorway_A").gameObject;
                    GameObject generatedWall = Instantiate(wall, door.transform.position, Quaternion.identity);
                    Destroy(door);
                }
                

                generatedRoom.transform.SetParent(gameObject.transform);
                map[x,z] = generatedRoom;

            }
        }
    }

    GameObject GetRandomRoom()
    {
        return room1Prefab;
    }
}
