using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int health;
    public int coins;
    public int completedRoom;
    private TextMeshProUGUI CoinsValueTextMesh;
    private TextMeshProUGUI CompletedRoomValueTextMesh;
    public GameManager gameManager;
    public int minimunRoomNumber = 2;
    // Start is called before the first frame update
    private void Awake()
    {
        //health = 100;
        coins = 0;
        completedRoom = 1;
    }
    void Start()
    {
        CoinsValueTextMesh = GameObject.Find("CoinsValueTextMesh").GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.FindWithTag("Map").GetComponent<GameManager>();
        CompletedRoomValueTextMesh = GameObject.Find("CompletedRoomValueTextMesh").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinsValueTextMesh.SetText(""+coins);
        CompletedRoomValueTextMesh.SetText(completedRoom + "/" + ((minimunRoomNumber + gameManager.Difficulty) * (minimunRoomNumber + gameManager.Difficulty)));
    }

    public bool pay(int c)
    {
           if(coins >= c)
        {
            coins -= c;
            return true;
        }
        return false;
    }
}
