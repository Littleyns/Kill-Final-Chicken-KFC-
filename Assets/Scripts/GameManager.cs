using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public Camera MainCamera;

    public GameObject gameInfosUI;
    public TextMeshProUGUI coinsValueTextMesh;
    public GameObject playerObject;
    public Rigidbody playerObjectRb;

    public PlayerManager playerManager;
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public int Difficulty { get; set; }

    public RigidbodyConstraints originalConstraints;
    public MapGenerator mapGenerator;
    public int minimunRoomNumber;
    // Start is called before the first frame update


    void Start()
    {

        GameCamera = GameObject.FindWithTag("GameCamera").GetComponent<Camera>();
        MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        playerObject = GameObject.FindWithTag("Player");
        switchToUIView();
        playerManager = playerObject.GetComponent<PlayerManager>();

        playerObjectRb = playerObject.GetComponent<Rigidbody>();

        originalConstraints = playerObjectRb.constraints;
        playerObjectRb.constraints = RigidbodyConstraints.FreezePositionY;
        minimunRoomNumber = playerManager.minimunRoomNumber;
    }

    // Update is called once per frame
    void Update()
    {
        coinsValueTextMesh.SetText(playerManager.coins.ToString());
    }

    public void switchToUIView()
    {
        gameInfosUI.SetActive(false);
        GameCamera.enabled = false;
        MainCamera.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void switchToGameView()
    {
        gameInfosUI.SetActive(true);
        GameCamera.enabled = true;
        MainCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartGame()
    {  
        /*if(GameObject.FindWithTag("NameText").GetComponent<TextMeshProUGUI>().text.Length > 1)
        {*/
            mapGenerator.GenerateMap();

            switchToGameView();
            playerObjectRb.constraints = originalConstraints;
        //}
    }


}
