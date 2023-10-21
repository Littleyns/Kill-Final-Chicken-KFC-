using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int health;
    public int coins;
    // Start is called before the first frame update
    private void Awake()
    {
        health = 100;
        coins = 50;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool pay(int c)
    {
           if(coins > c)
        {
            coins -= c;
            return true;
        }
        return false;
    }
}
