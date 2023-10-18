using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public Camera MainCamera;

    public string PlayerName { get; set; }
    public int Score { get; set; }
    public int Difficulty { get; set; }

    public MapGenerator mapGenerator;
    // Start is called before the first frame update
    void Start()
    {
        GameCamera = GameObject.FindWithTag("GameCamera").GetComponent<Camera>();
        MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mapGenerator = GameObject.FindWithTag("Map").GetComponent<MapGenerator>(); 

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
        switchToGameView();
    }


}
