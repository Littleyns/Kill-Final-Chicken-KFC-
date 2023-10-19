using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public Camera MainCamera;
    public GameObject gameManager;
    public GameObject cameraController;
    public GameObject playerObject;
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public int Difficulty { get; set; }

    public MapGenerator mapGenerator;
    // Start is called before the first frame update
    void Start()
    {
        GameCamera = GameObject.FindWithTag("GameCamera").GetComponent<Camera>();
        cameraController = GameObject.FindWithTag("playerCamera");
        MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mapGenerator = GameObject.FindWithTag("Map").GetComponent<MapGenerator>(); 
        gameManager = Resources.Load<GameObject>("GameManager");
        playerObject = Resources.Load<GameObject>("[ PLAYER SIMPLE ]");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchToUIView()
    {
        GameCamera.enabled = false;
        MainCamera.enabled = true;
    }
    public void switchToGameView()
    {
        GameCamera.enabled = true;
        MainCamera.enabled = false;
    }

    public void StartGame()
    {  
        mapGenerator.GenerateMap();
        if (gameManager != null)
        {
            // Instancier le prefab dans la scène
            GameObject nouvelObjet = Instantiate(gameManager);
            GameObject newPlayer = Instantiate(playerObject);
            cameraController.GetComponent<CamPivotController>().PlayerTarget = newPlayer.GetComponent<ThirdPersonController>();
        }
      
        switchToGameView();
    }


}
