using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapSize = 5; // Taille de la carte (5x5, par exemple)
    public int roomSize = 29;
    // Les modèles de salle de différentes tailles (3x3, 4x4, 5x5)
    public GameObject room1Prefab;
    public GameManager gameManager;
    public GameObject[,] map;

    void Start()
    {
        gameManager = GameObject.FindWithTag("Map").GetComponent<GameManager>();
        room1Prefab = Resources.Load("Room1") as GameObject;
    }

    public void GenerateMap()
    {
        map = new GameObject[3 + (gameManager.Difficulty), 3 + (gameManager.Difficulty)];
        for (int x = 0; x < 3+ gameManager.Difficulty; x++)
        {
            for (int z = 0; z < 3+ gameManager.Difficulty; z++)
            {
                // Choisissez une salle en fonction de la difficulté
                GameObject room = GetRandomRoom();

                // Instanciez la salle à la position (x, 0, z)
                GameObject generatedRoom = Instantiate(room, new Vector3(x * roomSize, 0, z * roomSize), Quaternion.identity);
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
